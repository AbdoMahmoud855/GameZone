using AutoMapper;
using Demo.BL.Interface;
using Demo.DAL._Data.Context;
using Demo.DAL._Data.Model;
using GameZone.Helper;
using GameZone.Helper.Attriputes;
using GameZone.Helper.Services.Interface;
using GameZone.Models.Games;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Server.Kestrel.Transport.NamedPipes;
using Microsoft.EntityFrameworkCore;
using System;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICreateServices _createServices;
        private readonly StoreContext _context;
        private readonly IGamesRpo _gamesRpo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public GamesController(
            ICreateServices createServices,
            StoreContext context,IUnitOfWork unitOfWork,IMapper mapper)
        {
            _createServices = createServices;
            _context = context;
            _gamesRpo=unitOfWork.gamesRpo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;


        }
        public async Task< IActionResult> Index()
        {
            var games =await _gamesRpo.GetAll(true);
            var gameView=_mapper.Map<IEnumerable< GamesViewModel>>(games);
            return View(gameView);
        }
        public async Task<IActionResult> Games()
        {
            return await Index();
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreateGameFormViewModel viewModel = new()
            {

                Devices = _createServices.GetSelectListDevices(),
                categories = _createServices.GetSelectListCategories(),
            };    
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
     
        public async Task<IActionResult> Create(CreateGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.categories= _createServices.GetSelectListCategories();
                model.Devices= _createServices.GetSelectListDevices();

                return View(model);
            }
                model.ImageName= DocumentSetting.UploadFileCompletedEventArgs(model.Cover, "Images");
            var viewModel=_mapper.Map<Game>(model);
          await  _gamesRpo.Add(viewModel!);
            await _unitOfWork.SaveChanges();


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id,string action = nameof(Detail) )
        {
            var model=await _gamesRpo.GetById(id);
            if (model == null)
                return NotFound(id);
            var viewmodel=_mapper.Map<GamesViewModel>(model);
            return View(action, viewmodel);

        }


        [HttpGet]

        public async Task<IActionResult> Edite(int id) {


            var model = await _gamesRpo.GetById(id);
            if (model == null)
                return NotFound(id);
            var viewModel = _mapper.Map<Game, EditeGamesViewModel>(model);
            viewModel.Devices = _createServices.GetSelectListDevices();
            viewModel.categories = _createServices.GetSelectListCategories();
            viewModel.ImageName=model.ImageName;
            return View(viewModel);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edite(EditeGamesViewModel model)
        {
            

            // Get existing game with tracking and includes
            var game =await _gamesRpo.GetById(model.Id);

            if (game is null)
                return NotFound();
            
            var oldCover = game.ImageName;

            // // Update simple properties
            game.Name = model.Name;
            game.Description = model.Description;
            game.CategoryId = model.CategoryId;
            game.Devices = model.SelectedDevices.Select(p => new GameDevice { DeviceId = p }).ToList();

            var oldmodel=_mapper.Map<Game,EditeGamesViewModel>(game);

            // Handle cover image
            if (model.Cover is not null)
            {
                game.ImageName = DocumentSetting.UploadFileCompletedEventArgs(model.Cover, "Images");
            }
          
            var effectRow= _context.SaveChanges();
            if (effectRow > 0)
            {
                if (model.Cover is not null)
                {
                    DocumentSetting.DeleteFile(oldCover, "Images");
                }
            }
          
           
            
              return RedirectToAction(nameof(Games));
            }

        [HttpDelete]
        public async Task< IActionResult> Delete(int id) {
            var game =await _gamesRpo.GetById(id);
            _gamesRpo.Delete(game);

            var effectRow = _context.SaveChanges();
            if (effectRow > 0)
            {
                DocumentSetting.DeleteFile(game.ImageName, "Images");
            }
            else
            {
                return BadRequest();  
            }
            
          
          
            return Ok();
        }


    }
}

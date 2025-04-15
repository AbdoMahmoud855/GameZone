namespace GameZone.Helper
{
    public class DocumentSetting
    {
        public static string UploadFileCompletedEventArgs(IFormFile file, string folderName)
        { //folder path store direction+wwwroot\\files\\foldername
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName);
            //generate unique filename
            string FileName = $"{Guid.NewGuid()}{file.FileName}";
            //file path
            string FilePath = Path.Combine(FolderPath, FileName);
            //save file as stream
            using var fs = new FileStream(FilePath, FileMode.Create);
            //help show image
            file.CopyTo(fs);
            return FileName;
        }
        public static void DeleteFile(string fileName, string folderName)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", folderName, fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}

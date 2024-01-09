namespace ViagemApi.Services
{
    public static class FotosService
    {
        public static string GerarCaminho(IFormFile foto)
        {
            var path = Path.Combine("Storage", foto.FileName);

            using Stream file = new FileStream(path, FileMode.Create);

            foto.CopyTo(file);

            return path;
        }
    }
}

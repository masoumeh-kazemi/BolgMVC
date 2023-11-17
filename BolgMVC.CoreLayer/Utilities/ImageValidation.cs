namespace BolgMVC.CoreLayer.Utilities;

public class ImageValidation
{
    public static bool Validate(string imageName)
    {
        var extension = Path.GetExtension(imageName);
        if (extension == null)
        {
            return false;
        }

        return extension.ToLower() == ".jpg" || extension.ToLower() == "png";
    }
}
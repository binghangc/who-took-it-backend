using who_took_it_backend.Models;

namespace who_took_it_backend.Services;

public static class ImageService
{
    static List<Image> Images { get; }
    static int nextId = 1;

    static ImageService()
    {
        Images = new List<Image>();
    }

    public static List<Image> GetAll() => Images;

    public static Image? Get(int id) => Images.FirstOrDefault(i => i.Id == id);

    public static void Add(Image image)
    {
        image.Id = nextId++;
        Images.Add(image);
    }

    public static void Delete(int id)
    {
        var image = Get(id);
        if (image is null)
            return;

        Images.Remove(image);
    }

    public static void Update(Image image)
    {
        var index = Images.FindIndex(i => i.Id == image.Id);
        if (index == -1)
            return;

        Images[index] = image;
    }
}
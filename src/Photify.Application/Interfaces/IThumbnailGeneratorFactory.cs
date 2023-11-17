namespace Photify.Application.Interfaces;

public interface IThumbnailGeneratorFactory
{
    IThumbnailGenerator GetThumbnailGenerator(string format);
}

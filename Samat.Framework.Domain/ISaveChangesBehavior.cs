namespace Samat.Framework.Domain;

public interface ISaveChangesBehavior
{
    bool DisableSaveChangeOnCommandHandler();
}
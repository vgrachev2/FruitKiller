using Assets.Scripts.Entity;

namespace Assets.Scripts.Grid.EntityPositionCalculator
{
    public interface IEntityGridCreator
    {
        EntityGrid EntityGridCreate(EntityPositionPlacerProperties properties);
    }
}

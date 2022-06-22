using DataCore.Metadata;

namespace DataCore.Payload;

public class EntityState
{
    private EntityStateKind _kind;
    private object _previousEntity;

    public EntityState()
    {
    }

    public EntityState(object previousEntity, EntityStateKind kind)
    {
        _previousEntity = previousEntity;
        _kind = kind;
    }

    public object GetPreviousEntity()
    {
        return _previousEntity;
    }

    public void SetPreviousEntity(object previousEntity)
    {
        _previousEntity = previousEntity;
    }

    public EntityStateKind GetKind()
    {
        return _kind;
    }

    public void SetKind(EntityStateKind kind)
    {
        _kind = kind;
    }
}
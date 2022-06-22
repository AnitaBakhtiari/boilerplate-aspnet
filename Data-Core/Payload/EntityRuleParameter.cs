using DataCore.Metadata;
using DataCore.Model;

namespace DataCore.Payload;

public class EntityRuleParameter<TEntity> where TEntity : ICoreEntity
{
    private TEntity _previousEntity;
    private EntityStateKind _state;

    public EntityRuleParameter()
    {
    }

    public EntityRuleParameter(EntityStateKind state, TEntity previousEntity)
    {
        _state = state;
        _previousEntity = previousEntity;
    }

    public EntityStateKind GetState()
    {
        return _state;
    }

    public void SetState(EntityStateKind state)
    {
        _state = state;
    }

    public TEntity GetPreviousEntity()
    {
        return _previousEntity;
    }

    public void SetPreviousEntity(TEntity previousEntity)
    {
        _previousEntity = previousEntity;
    }
}
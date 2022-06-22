using Core.Payload;
using DataCore.Metadata;

namespace DataSql.Payload;

public class InProgressValidation : IPayload
{
    private object _entity;

    private EntityStateKind _kind;

    public InProgressValidation()
    {
    }

    public InProgressValidation(object entity, EntityStateKind kind)
    {
        _entity = entity;
        _kind = kind;
    }

    public object GetEntity()
    {
        return _entity;
    }

    public void SetEntity(object entity)
    {
        _entity = entity;
    }

    public EntityStateKind GetKind()
    {
        return _kind;
    }

    public void SetKind(EntityStateKind kind)
    {
        _kind = kind;
    }


    //public bool equals(Object o)
    //{
    //    if (this == o) return true;
    //    if (o == null || getClass() != o.getClass()) return false;
    //    InProgressValidation that = (InProgressValidation)o;
    //    return Objects.equals(_entity, that._entity) &&
    //           _kind == that._kind;
    //}


    //public int hashCode()
    //{
    //    return Objects.hash(_entity.hashCode(), _kind);
    //}
}
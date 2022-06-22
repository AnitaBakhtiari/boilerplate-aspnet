using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataSql.Model;

public abstract class BaseEntity : IBaseEntity
{
    [Key]
    public long Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
    public long Version { get; set; }

    //public string GetId()
    //{
    //    return Id;
    //}

    //public void SetId(string id)
    //{
    //    Id = id;
    //}

    //public DateTime GetCreated()
    //{
    //    return Created;
    //}

    //public void SetCreated(DateTime created)
    //{
    //    Created = created;
    //}

    //public DateTime GetModified()
    //{
    //    return Modified;
    //}

    //public void SetModified(DateTime modified)
    //{
    //    Modified = modified;
    //}

    //public long GetVersion()
    //{
    //    return Version;
    //}

    //public void SetVersion(long version)
    //{
    //    Version = version;
    //}
}
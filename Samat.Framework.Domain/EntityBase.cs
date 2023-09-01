namespace Samat.Framework.Domain;

public abstract class EntityBase<TKey> 
{
    public TKey Id { get; set; }

    public override bool Equals(object? obj)
    {
        return Equals(obj as EntityBase<TKey>);
    }

    private bool Equals(EntityBase<TKey>? other)
    {
        return other is not null &&
               EqualityComparer<TKey>.Default.Equals(Id, other.Id);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}
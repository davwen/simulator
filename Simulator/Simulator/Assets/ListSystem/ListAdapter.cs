using UnityEngine;

public abstract class ListAdapter
{
    /// <summary>Called when an item has been inserted to a list.</summary>
    public abstract void OnItemInsert(ListItemData data);

    /// <summary>Called when an item has been removed to a list.</summary>
    public abstract void OnItemRemove(int index);

    /// <summary>Called when an item inside a list has been updated.</summary>
    public abstract void OnItemUpdate(ListItemData data);

    /// <summary>Call this method to specify the length of the list.</summary>
    public abstract int GetCount();

    /// <summary>You can provide an item prefab to the listCreator using this method.</summary>
    public virtual GameObject GetItemPrefab(int index) { return default; }
}

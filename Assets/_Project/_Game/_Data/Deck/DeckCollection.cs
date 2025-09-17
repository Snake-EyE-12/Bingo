using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeckCollection
{
    private List<IDeckCollectable> full;
    private List<IDeckCollectable> hand;
    private List<IDeckCollectable> discard;
    private List<IDeckCollectable> draw;
    
    public List<IDeckCollectable> Full => full;
    public List<IDeckCollectable> Hand => hand;
    public List<IDeckCollectable> DiscardPile => discard;
    public List<IDeckCollectable> DrawPile => draw;

    public DeckCollection(List<IDeckCollectable> collection)
    {
        full = collection;
        hand = new();
        discard = new();
        draw = new();
    }

    public void Add(IDeckCollectable collectable)
    {
        full.Add(collectable);
        SortFull();
    }

    public void Remove(IDeckCollectable collectable)
    {
        full.Remove(collectable);
    }

    public void SortFull()
    {
        full = full.OrderBy((x) => x.SortValue).ToList();
    }

    public void SortHand()
    {
        hand = hand.OrderBy((x) => x.SortValue).ToList();
    }

    public void Shuffle()
    {
        Reset();
        draw.AddRange(full);
        draw = draw.OrderBy((x) => Random.value).ToList();
    }

    private void Reset()
    {
        hand.Clear();
        draw.Clear();
        discard.Clear();
    }

    public IDeckCollectable Draw()
    {
         if(DrawPile.Count == 0) return null;
         IDeckCollectable collectable = DrawPile[0];
         DrawPile.RemoveAt(0);
         hand.Add(collectable);
         collectable.OnDraw();
         return collectable;
    }

    public List<IDeckCollectable> Draw(int amount)
    {
        amount = Mathf.Clamp(amount, 0, DrawPile.Count);
        List<IDeckCollectable> result = new List<IDeckCollectable>();
        for (int i = 0; i < amount; i++)
        {
            result.Add(Draw());
        }
        return result;
    }

    public void Discard(IDeckCollectable collectable)
    {
        hand.Remove(collectable);
        discard.Add(collectable);
        collectable.OnDiscard();
    }

    public void Discard(List<IDeckCollectable> collectables)
    {
        List<IDeckCollectable> result = new List<IDeckCollectable>(collectables);
        result.ForEach((x) => Discard(x));
    }
    
    public void Play(IDeckCollectable collectable)
    {
        hand.Remove(collectable);
    }
    
    public void Play(List<IDeckCollectable> collectables)
    {
        List<IDeckCollectable> result = new List<IDeckCollectable>(collectables);
        result.ForEach((x) => Play(x));
    }
}

public interface IDeckCollectable
{
    public int SortValue { get; }
    public void OnDiscard();
    public void OnDraw();
}
using System;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;

public class ChipCollection : MonoBehaviour
{
    private const int values = 75;
    private DeckCollection collection;

    private void Awake()
    {
        LoadInitialCollection();
        collection.Shuffle();
    }

    private void LoadInitialCollection()
    {
        List<IDeckCollectable> chips = new();
        for (int i = 1; i <= values; i++)
        {
            chips.Add(new Chip(i));
        }
        collection = new DeckCollection(chips);
    }

    public void DrawHand()
    {
        collection.Draw(8);
        Facade.OnHandUpdate?.Invoke(collection.Hand.Cast<Chip>().ToList());
    }
    public void DiscardHand()
    {
        collection.Discard(collection.Hand);
    }

    public List<Chip> PlayHand()
    {
        Debug.Log("Played: " + collection.Hand.Count);
        var hand = new List<IDeckCollectable>((collection.Hand));
        collection.Play(collection.Hand);
        return hand.Cast<Chip>().ToList();
    }
}

public class Chip : IDeckCollectable
{
    private int value;
    public int Value => value;

    public Chip(int value)
    {
        this.value = value;
    }

    public int SortValue { get => value; }
    public void OnDiscard()
    {
        
    }

    public void OnDraw()
    {
        
    }

    public override string ToString()
    {
        return "Chip: "  + value;
    }
}
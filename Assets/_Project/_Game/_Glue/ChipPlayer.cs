using UnityEngine;

public class ChipPlayer : MonoBehaviour
{
    [SerializeField] private ChipCollection chipCollection;
    [SerializeField] private BoardPlayer boardPlayer;
    public void Play()
    {
        boardPlayer.Play(chipCollection.PlayHand());
    }

    public void Discard()
    {
        chipCollection.DiscardHand();
    }

    public void Draw()
    {
        chipCollection.DrawHand();
    }
}
using NaughtyAttributes;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] ChipPlayer chipPlayer;
    [Button("Play")]
    public void PlayTest()
    {
        chipPlayer.Play();
    }

    [Button("Discard")]
    public void DiscardTest()
    {
        chipPlayer.Discard();
    }

    [Button("Draw")]
    public void DrawHand()
    {
        chipPlayer.Draw();
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    [SerializeField] private List<Card> currentDeck;
    [SerializeField] private int deckSize;
    [SerializeField] private int currentDeckSize;
    [SerializeField] private int firstDraw;
    [SerializeField] private List<Image> deckCardBacks = new List<Image>();
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private List<GameObject> hand = new List<GameObject>();
    [SerializeField] private AudioSource addCardSoundEffect;

    private bool drawing;

    // Start is called before the first frame update
    void Start()
    {
        int randomNumber, i;
        
        for (i = 0; i < deckSize; i++) {
            randomNumber = Random.Range(0, CardDataBase.CardList.Count);
            deck.Add(CardDataBase.CardList[randomNumber]);
        }

        currentDeck = deck.ToList();
        currentDeckSize = deckSize;

    }

    public IEnumerator DrawFirstCards() {
        for (int i = 0; i < firstDraw; i++) {
            yield return new WaitForSeconds(0.5f);
            DrawCard();
        }
    }

    public void DrawCard() {
        var panel = GameObject.Find("HandArea");

        if (currentDeckSize > 0) {
            currentDeckSize--;

            if (currentDeckSize < 1) {
                deckCardBacks[0].gameObject.SetActive(false);
            }
            else if (currentDeckSize < 2) {
                deckCardBacks[1].gameObject.SetActive(false);
            }
            else if (currentDeckSize < 3) {
                deckCardBacks[2].gameObject.SetActive(false);
            }

            var card = Instantiate(cardPrefab, transform.position, transform.rotation);
            addCardSoundEffect.Play();
            card.transform.SetParent(panel.transform);
            card.GetComponent<CardDisplay>().Init(currentDeck[0]);

            hand.Add(card);
            currentDeck.Remove(currentDeck[0]);

            if (currentDeckSize == 0) {
                Shuffle();
            }
        }
    }

    public void Shuffle() {
        Card tempCard;
        int randomNumber;

        for (int i = 0; i < deckSize; i++) {
            tempCard = deck[i];
            randomNumber = Random.Range(i, deckSize);
            deck[i] = deck[randomNumber];
            deck[randomNumber] = tempCard;
        }

        currentDeck = deck.ToList();
        foreach (GameObject card in hand) {
            if(card == null) continue;
            int index = currentDeck.FindIndex(x => x.id == card.GetComponent<CardDisplay>().id);
            currentDeck.RemoveAt(index);
        }

        currentDeckSize = currentDeck.Count();

        if (currentDeckSize > 3)
        {
            deckCardBacks[0].gameObject.SetActive(true);
            deckCardBacks[1].gameObject.SetActive(true);
            deckCardBacks[2].gameObject.SetActive(true);
        }
        else if (currentDeckSize > 2)
        {
            deckCardBacks[0].gameObject.SetActive(true);
            deckCardBacks[1].gameObject.SetActive(true);
        }
        else if(currentDeckSize > 1)
        {
            deckCardBacks[0].gameObject.SetActive(true);
        }
    }
}

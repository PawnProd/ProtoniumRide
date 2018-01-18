using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchatDisplay : MonoBehaviour {

    /// <summary>
    /// L'image représentant l'objet
    /// </summary>
    public Image objImg;

    /// <summary>
    /// L'image de la catégorie de l'objet
    /// </summary>
    public Image categorieImg;

    /// <summary>
    /// Le nom de l'objet
    /// </summary>
    public Text objName;

    /// <summary>
    /// Le prix de l'objet
    /// </summary>
    public Text objPrice;

    /// <summary>
    /// Display les différents élément d'achat
    /// </summary>
    /// <param name="objSprite"> L'image de l'objet</param>
    /// <param name="catSprite"> L'image de la catégorie</param>
    /// <param name="name"> Le nom de l'objet</param>
    /// <param name="price"> Le prix de l'objet</param>
   public void Display(Sprite objSprite, Sprite catSprite, string name, string price)
    {
        objImg.sprite = objSprite;
        categorieImg.sprite = catSprite;
        objName.text = name;
        objPrice.text = price;
    }
}

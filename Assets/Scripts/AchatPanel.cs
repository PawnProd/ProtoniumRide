using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchatPanel : MonoBehaviour {

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
    /// Change l'image de l'objet dans le shop
    /// </summary>
    /// <param name="objSprite"> La nouvelle image de l'objet</param>
	public void SetObjImg(Sprite objSprite)
    {
        objImg.sprite = objSprite;
    }

    /// <summary>
    /// Change l'image de la catégorie de l'objet dans le shop
    /// </summary>
    /// <param name="categorieSprite"> La nouvelle image de la catégorie</param>
    public void SetCategorieImg(Sprite categorieSprite)
    {
        categorieImg.sprite = categorieSprite;
    }

    /// <summary>
    /// Change le nom de l'objet dans le shop
    /// </summary>
    /// <param name="name"> Le nouveau nom de l'objet</param>
    public void SetObjName(string name)
    {
        objName.text = name;
    }

    /// <summary>
    /// Change le prix de l'objet dans le shop
    /// </summary>
    /// <param name="price"> Le nouveau prix de l'objet</param>
    public void SetObjPrice(string price)
    {
        objPrice.text = price;
    }
}

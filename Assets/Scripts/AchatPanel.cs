using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Achat Object")]
public class AchatPanel : ScriptableObject {

    /// <summary>
    /// L'id de référence au gameobject
    /// </summary>
    public int id;

    /// <summary>
    /// L'image représentant l'objet
    /// </summary>
    public Sprite objImg;

    /// <summary>
    /// La catégorie de l'objet
    /// </summary>
    public CategorieAchat categorie;

    /// <summary>
    /// L'image de la catégorie de l'objet
    /// </summary>
    public Sprite categorieImg;

    /// <summary>
    /// Le nom de l'objet
    /// </summary>
    public string objName;

    /// <summary>
    /// Le prix de l'objet
    /// </summary>
    public int objPrice;

    /// <summary>
    /// Détermine si l'objet a été acheté ou non
    /// </summary>
    public bool isBuy;

}

public enum CategorieAchat
{
    module,
    cosmetique,
    ressource,
    vfx
}

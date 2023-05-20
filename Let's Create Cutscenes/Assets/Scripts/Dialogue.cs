using UnityEngine;

/*
 * Essa classe serve apenas para armazenar informações sobre
 * quais falas serão apresentadas e qual imagem é exibida,
 * sendo que cada personagem participante possui uma instância dela
*/

[System.Serializable]
public class Dialogue {

    public AnimationClip[] animations;

    [TextArea(1, 40)]
    public string[] sentences;

}

using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{

    public Animator animationController;

    private float inputHorizontal, inputVertical;
    private bool isRunning, isJumping;

    private void Start() {

        animationController = GetComponent<Animator>();
        isRunning = false;

    }

    private void Update() {

        /* --- Coloca as IdleAnimations nos números do teclado --- */

        if (Input.GetKeyDown(KeyCode.Alpha1)) {

            // 1° Param --> Nome da animação a ser executada
            // 2° Param --> Qual Layer ela está. Por padrão elas são colocadas no BaseLayer = -1
            // 3° Param --> Em que momento inicia a animação 0f (começo) à 1f (final) [0.5f é o meio]
            // Ao colocar o 3° Param --> A animação pode ser interrompida
            animationController.Play("WAIT01", -1);

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
            animationController.Play("WAIT02", -1, 0.5f); // Como há 0.5f, a animação irá iniciar na metade

        if (Input.GetKeyDown(KeyCode.Alpha3))
            animationController.Play("WAIT03", -1);

        if (Input.GetKeyDown(KeyCode.Alpha4))
            animationController.Play("WAIT04", -1);

        if (Input.GetMouseButtonDown(0)) {

            float randomAnimation = Random.Range(0, 2);

            if (randomAnimation == 1)
                animationController.Play("DAMAGED00", -1, 0f);
            else
                animationController.Play("DAMAGED01", -1, 0f);

        }

        /* --- Estabelece valores para os eixos que serão usados para identificar qual animação de movimento usar --- */

        // O Eixo (Axis) é uma simetria de valores
        // Horizontal: "a" movimenta para a esquerda --> valor máximo é -1 (valores negativos)
        // Horizontal: "d" movimenta para a direita --> valor máximo é +1 (valores positivos)
        // 0 quando nenhum dos eixo está sendo pressinado
        // Vertical: "s" são valores negativos, "w" são valores positivos
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");

        // Colocamos um valor a um parâmetro float definido no animator com o SetFloat()
        // 1° Param --> é o nome do parâmetro no animator
        // 2° Param --> é o valor que desejamos dar
        animationController.SetFloat("inputHorizontal", inputHorizontal);
        animationController.SetFloat("inputVertical", inputVertical);

        /* --- Implementa animações de corrida --- */

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
            isRunning = true;
        }
        else {
            isRunning = false;
        }

        // Coloca o valor do parâmetro no animator de acordo com a variável
        animationController.SetBool("isRunning", isRunning);

        /* --- Implementa animação de pulo --- */

        if (Input.GetKeyDown(KeyCode.Space)) {
            isJumping = true;
        }
        else {
            isJumping = false;
        }

        animationController.SetBool("isJumping", isJumping);

    }

    private void FixedUpdate() {


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainConstants : MonoBehaviour
{
    //Scenes
    public static int INDEX_SCENE_ISLAND = 0;
    public static int INDEX_SCENE_MAP = 1;

    //Actions
    public static string INTERACT_INTERACTION = "Interact";

    //Notifications
    public static string NOTIFICATION_MAP = "Pulsa 'E' para embarcarte en una misión";

    //ReputationUI
    public static int DEFAULT_REPUTATION = 0;
    public static int GOOD_REPUTATION = 1;
    public static int BEST_REPUTATION = 2;
    public static int BAD_REPUTATION = 3;
    public static int WORST_REPUTATION = 4;

    //Events
    public static int EVENT_UNKNOWN = 0;
    public static int EVENT_BLESS = 1;
    public static int EVENT_CHEST = 2;
    public static int EVENT_OASIS = 3;
    public static int EVENT_SHARK = 4;
    public static int EVENT_RESCUE = 5;
    public static int EVENT_BATTLE = 6;
    public static int EVENT_BOSS = 7;

    //NPC Dialogue
    public static string[] NPCShopDialogue = {"Bueno, bonito y barato. ¡Me lo quitan de las manos!",
        "¿Ves algo que te guste?", "Si nadie me compra, voy a tener que cerrar el chiringuito.",
        "Venga que hoy invita la casa. O no...", "Si no te gusta lo que vendo, siempre puedes montarte tu propia tienda."};
    
    public static string[] NPCDialogue = {"Como están los máquinas lo primero de todo.",
        "Últimamente el mar se ha convertido en un sitio peligroso.",
        "Los tiempos han cambiado, este pueblo ya no es lo que era.",
        "Me crié en este lugar, es una pena ver en lo que se ha convertido.",
        "¿Eres el pirata del que habla todo el mundo? Me das un poco de miedo, pero tu eficacia es innegable...",
        "Últimamente se ven muchas caras nuevas por aquí... Gracias.",
        "No debería estar hablando contigo, pero no me pareces tan malo como se comenta por ahí.",
        "Es un secreto, pero estoy pensando en unirme a tu banda. No se lo digas a nadie, ¿eh?",
        "Quizá no todos los piratas den miedo después de todo.",
        "Ojalá este pueblo volviera a su antigua gloria.",
        "Solía pasear por aquí a todas horas, antes me hacía feliz, pero ahora da un poco de pena.",
        "Creo que es la décima vez que hago este recorrido hoy.",
        "¿No he hablado contigo ya hace un rato?",
        "Mi pareja y yo estamos pensando en mudarnos a esta ciudad, ¿han solucionado ya el problemilla de la piratería?",
        "He oído que en la tienda venden objetos increíbles, ¿pero cuándo voy a usar yo una daga de combate?",
        "La encargada de la tienda no para de mirarme, yo creo que le gusto...",
        "¿Tú crees que la encargada de la tienda está bien? No la he visto moverse en todo el día.",
        "Una cosa te voy a decir... dos escopetas tengo.",
        "¿Qué quiere decir '4 8 15 16 23 42'? ¡Es la quinta vez que veo esos números desde que me mudé a aquí!",
        "He oído leyendas de que hay partes de esta isla donde pasan cosas muy extrañas.",
        "A veces siento que me observan cuando paseo por aquí, ¿creen que hay otros viviendo en esta isla? ¡Qué miedo!",
        "El otro día paseando por la isla me encontré un búnker subterrano. ¿Cómo? ¿No me crees?",
        "Existen muchas leyendas sobre seres misterioros que habitan estas aguas. ¿Has oído hablar del Selkidomus?",
        "Mi vecino no para de llamarme 'Jueves' porque es el día en el que nos conocimos, ¿no es un poco raro?",
        "No suele haber muchos niños por aquí, menos mal ¿eh? ¡Una isla como esta sería todo un peligro!",
        "Mi madre siempre decía que en la vida hay que arriesgarse y actuar a lo grande incluso cuando se hacen cosas pequeñas. Toma nota de ello.",
        "¿Mal día? No te preocupes, hasta del limón más agrio se puede hacer algo que parezca limonada...",
        "Lo bueno de que los días sean tan largos es que aunque te pase algo malo, siempre puede pasar otra cosa que te haga recordarlo de otra manera.",
        "¿Has entrado alguna vez en la tienda? Esa cosa no tiene sentido. ¡Parece más grande por dentro!",
        "Muchas personas están en tu contra, pero no conozco a nadie más que se despierte cada día y luche por hacer del mundo un lugar mejor.",
        "La vida de cada persona es un conjunto de constantes y variables. ¿No es poético?",
        "Hace unos años me fastidié el dedo méñique, ahora uso un dedal para cubrir mi 'horrible deformidad' jajaja.",
        "No puedo decir que apoye tus métodos, pero no puedo expresar con palabras la gratitud que te tengo.",
        "Supongo que hay veces en las que hay que apoyar la piratería, ¿no? No sé si termina de convencerme...",
        "Me da vergüenza hablar contigo, pero siento como si una fuerza me impulsara a hacerlo.",
        "¿Puedo continuar andando? Tengo una cita y creo que voy a llegar tarde...",
        "Juraría que quería caminar en otra dirección, ¿por qué sigo por aquí?"};
}

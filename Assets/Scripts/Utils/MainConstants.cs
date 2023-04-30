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
    public static string NOTIFICATION_MAP = "Pulsa 'E' para embarcarte en una misi�n";

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

    //Event name
    public static string NAME_UNKNOWN = "Evento Desconocido";
    public static string NAME_BLESS = "Evento Caverna misteriosa";
    public static string NAME_CHEST = "Evento Bot�n pirata";
    public static string NAME_OASIS = "Evento Oasis milagroso";
    public static string NAME_SHARK = "Evento Ataque de tiburones";
    public static string NAME_RESCUE = "Evento Rescate";
    public static string NAME_BATTLE = "Evento Combate";
    public static string NAME_BOSS = "Evento Jefe Final";

    //Event explanation
    public static string EXPLANATION_UNKNOWN = "La tripulaci�n se ha encontrado con un evento desconocido.\nRealmente este evento invocar�a a cualquiera de los otros y tendr�a las consecuencias del evento seleccionado de manera aleatoria.";
    public static string EXPLANATION_BLESS = "La tripulaci�n se ha encontrado con una misteriosa caverna que desprende un halo misterioso.\nParece que dentro se encontraba 'nombre de objeto', famoso por 'explicaci�n de objeto'.\nSe comenta que su uso puede tener consecuencias nefastas. �Lo recoges?";
    public static string EXPLANATION_CHEST = "�Pero qu� ven mis ojos! La tripulaci�n se ha encontrado con un hermoso bot�n pirata escondido a�os atr�s. Supongo que nadie lo echar� de menos...\nLa tripulaci�n recibe monedas de oro";
    public static string EXPLANATION_OASIS = "�Tierra a la vista! �Ser� una agradable zona de descanso o un espejismo causado por el cansancio?\nLa tripulaci�n descansa, recuperando parte de sus Puntos de Salud";
    public static string EXPLANATION_SHARK = "Las aguas parecen m�s agitadas y hostiles que de costumbre. �Tiburones arremeten contra el barco!\nLa tripulaci�n pierde Puntos de Salud y monedas de oro.";
    public static string EXPLANATION_RESCUE = "�Socorro! �Parece que alguien est� siendo atacado por otros piratas!\n�Debe la tripulaci�n ir en su auxilio?";
    public static string EXPLANATION_BATTLE = "Monstruos horribles vienen al ataque. �Hora de pasar a la acci�n!";
    public static string EXPLANATION_BOSS = "Este enemigo no se parece en nada a los peligros enfrentados hasta ahora.\nSer� mejor que la tripulaci�n se prepare...";

    //NPC Dialogue
    public static string[] NPCShopDialogue = {"Bueno, bonito y barato. �Me lo quitan de las manos!",
        "�Ves algo que te guste?", "Si nadie me compra, voy a tener que cerrar el chiringuito.",
        "Venga que hoy invita la casa. O no...", "Si no te gusta lo que vendo, siempre puedes montarte tu propia tienda."};

    public static string[] NPCShopBuy = { "�Gracias por su compra!", "Un placer hacer negocios con mi cliente favorito.",
    "�Ves algo m�s que sea de tu agrado?"};

    public static string[] NPCShopNoMoney = { "Si no tienes dinero para pagarlo no voy a d�rtelo �eh?", "No insistas, veo que tienes la cartera vac�a.",
    "�Por qu� no te vas a saquear otro sitio por ah�?"};

    public static string[] NPCDialogue = {"Como est�n los m�quinas lo primero de todo.",
        "�ltimamente el mar se ha convertido en un sitio peligroso.",
        "Los tiempos han cambiado, este pueblo ya no es lo que era.",
        "Me cri� en este lugar, es una pena ver en lo que se ha convertido.",
        "�Eres el pirata del que habla todo el mundo? Me das un poco de miedo, pero tu eficacia es innegable...",
        "�ltimamente se ven muchas caras nuevas por aqu�... Gracias.",
        "No deber�a estar hablando contigo, pero no me pareces tan malo como se comenta por ah�.",
        "Es un secreto, pero estoy pensando en unirme a tu banda. No se lo digas a nadie, �eh?",
        "Quiz� no todos los piratas den miedo despu�s de todo.",
        "Ojal� este pueblo volviera a su antigua gloria.",
        "Sol�a pasear por aqu� a todas horas, antes me hac�a feliz, pero ahora da un poco de pena.",
        "Creo que es la d�cima vez que hago este recorrido hoy.",
        "�No he hablado contigo ya hace un rato?",
        "Mi pareja y yo estamos pensando en mudarnos a esta ciudad, �han solucionado ya el problemilla de la pirater�a?",
        "He o�do que en la tienda venden objetos incre�bles, �pero cu�ndo voy a usar yo una daga de combate?",
        "La encargada de la tienda no para de mirarme, yo creo que le gusto...",
        "�T� crees que la encargada de la tienda est� bien? No la he visto moverse en todo el d�a.",
        "Una cosa te voy a decir... dos escopetas tengo.",
        "�Qu� quiere decir '4 8 15 16 23 42'? �Es la quinta vez que veo esos n�meros desde que me mud� a aqu�!",
        "He o�do leyendas de que hay partes de esta isla donde pasan cosas muy extra�as.",
        "A veces siento que me observan cuando paseo por aqu�, �creen que hay otros viviendo en esta isla? �Qu� miedo!",
        "El otro d�a paseando por la isla me encontr� un b�nker subterrano. �C�mo? �No me crees?",
        "Existen muchas leyendas sobre seres misterioros que habitan estas aguas. �Has o�do hablar del Selkidomus?",
        "Mi vecino no para de llamarme 'Jueves' porque es el d�a en el que nos conocimos, �no es un poco raro?",
        "No suele haber muchos ni�os por aqu�, menos mal �eh? �Una isla como esta ser�a todo un peligro!",
        "Mi madre siempre dec�a que en la vida hay que arriesgarse y actuar a lo grande incluso cuando se hacen cosas peque�as. Toma nota de ello.",
        "�Mal d�a? No te preocupes, hasta del lim�n m�s agrio se puede hacer algo que parezca limonada...",
        "Lo bueno de que los d�as sean tan largos es que aunque te pase algo malo, siempre puede pasar otra cosa que te haga recordarlo de otra manera.",
        "�Has entrado alguna vez en la tienda? Esa cosa no tiene sentido. �Parece m�s grande por dentro!",
        "Muchas personas est�n en tu contra, pero no conozco a nadie m�s que se despierte cada d�a y luche por hacer del mundo un lugar mejor.",
        "La vida de cada persona es un conjunto de constantes y variables. �No es po�tico?",
        "Hace unos a�os me fastidi� el dedo m��ique, ahora uso un dedal para cubrir mi 'horrible deformidad' jajaja.",
        "No puedo decir que apoye tus m�todos, pero no puedo expresar con palabras la gratitud que te tengo.",
        "Supongo que hay veces en las que hay que apoyar la pirater�a, �no? No s� si termina de convencerme...",
        "Me da verg�enza hablar contigo, pero siento como si una fuerza me impulsara a hacerlo.",
        "�Puedo continuar andando? Tengo una cita y creo que voy a llegar tarde...",
        "Jurar�a que quer�a caminar en otra direcci�n, �por qu� sigo por aqu�?"};
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainConstants : MonoBehaviour
{
    //Constant values
    public static int MONEY_CHEST = 100;

    //Scenes
    public static int INDEX_SCENE_ISLAND = 1;
    public static int INDEX_SCENE_MAP = 2;
    public static int INDEX_SCENE_BATTLE = 3;

    //Actions
    public static string INTERACT_INTERACTION = "Interact";

    //Text color
    public static int COLOR_BLACK = 0;
    public static int COLOR_GREEN = 1;
    public static int COLOR_RED = 2;

    //Reputation discount and recharge
    public static int DISCOUNT_PERCENT = 80;                                            //Percent after discount
    public static int RECHARGE_PERCENT = 120;                                           //Percent after recharge

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
    public static int EVENT_BLACKMARKET = 8;
    public static int EVENT_SHORTCUT = 9;

    //Event name
    public static string NAME_UNKNOWN = "Evento Desconocido";
    public static string NAME_BLESS = "Evento Caverna misteriosa";
    public static string NAME_CHEST = "Evento Bot�n pirata";
    public static string NAME_OASIS = "Evento Oasis milagroso";
    public static string NAME_SHARK = "Evento Ataque de tiburones";
    public static string NAME_RESCUE = "Evento Rescate";
    public static string NAME_BATTLE = "Evento Combate";
    public static string NAME_BOSS = "Evento Jefe Final";
    public static string NAME_BLACKMARKET = "Evento Mercado Negro";
    public static string NAME_SHORTCUT = "Evento Pasaje Corsario";

    //Event explanation
    public static string EXPLANATION_UNKNOWN = "La tripulaci�n se ha encontrado con un evento desconocido.\nRealmente este evento invocar�a a cualquiera de los otros y tendr�a las consecuencias del evento seleccionado de manera aleatoria.";
    public static string EXPLANATION_BLESS = "La tripulaci�n se ha encontrado con una misteriosa caverna.\nParece que dentro se encontraba una Mesa de destiler�a casera, muy �til para fabricar poderosos brebajes que lanzar a tus enemigos.\nSin embargo, no est� muy bien recibida entre los buenos piratas. �Lo recoges?";
    public static string EXPLANATION_CHEST = "�Pero qu� ven mis ojos! La tripulaci�n se ha encontrado con un hermoso bot�n pirata escondido a�os atr�s. Supongo que nadie lo echar� de menos...\nLa tripulaci�n recibe monedas de oro";
    public static string EXPLANATION_OASIS = "�Tierra a la vista! �Ser� una agradable zona de descanso o un espejismo causado por el cansancio?\nLa tripulaci�n descansa, recuperando parte de sus Puntos de Salud";
    public static string EXPLANATION_SHARK = "Las aguas parecen m�s agitadas y hostiles que de costumbre. �Tiburones arremeten contra el barco!\nLa tripulaci�n pierde Puntos de Salud y monedas de oro.";
    public static string EXPLANATION_RESCUE = "�Socorro! �Parece que alguien est� siendo atacado por otros piratas!\n�Debe la tripulaci�n ir en su auxilio?";
    public static string EXPLANATION_BATTLE = "Monstruos horribles vienen al ataque. �Hora de pasar a la acci�n!";
    public static string EXPLANATION_BOSS = "Este enemigo no se parece en nada a los peligros enfrentados hasta ahora.\nSer� mejor que la tripulaci�n se prepare...";
    public static string EXPLANATION_BLACKMARKET = "Aqu� aparec�r� una tienda como la de la isla principal, pero con objetos del mercado negro.";
    public static string EXPLANATION_SHORTCUT = "Los corsarios de buena reputaci�n reconocen a la tripulaci�n como miembros de los suyos.\nLa tripulaci�n utiliza un pasaje secreto para evitar algunas amenazas y obtener importantes recompensas.";

    //Event Percentage Neutral value
    public static int NEUTRAL_UNKNOWN = 20;
    public static int NEUTRAL_OASIS = 10;
    public static int NEUTRAL_RESCUE = 10;
    public static int NEUTRAL_SHARK = 10;
    public static int NEUTRAL_CHEST = 15;
    public static int NEUTRAL_BATTLE = 30;
    public static int NEUTRAL_BLESS = 5;
    public static int NEUTRAL_BOSS = 100;
    public static int NEUTRAL_BLACKMARKET = 0;
    public static int NEUTRAL_SHORTCUT = 0;

    //Event Percentage Good value
    public static int GOOD_UNKNOWN = 18;
    public static int GOOD_OASIS = 10;
    public static int GOOD_RESCUE = 10;
    public static int GOOD_SHARK = 7;
    public static int GOOD_CHEST = 15;
    public static int GOOD_BATTLE = 30;
    public static int GOOD_BLESS = 5;
    public static int GOOD_BOSS = 100;
    public static int GOOD_BLACKMARKET = 0;
    public static int GOOD_SHORTCUT = 5;

    //Event Percentage Best value
    public static int BEST_UNKNOWN = 16;
    public static int BEST_OASIS = 10;
    public static int BEST_RESCUE = 7;
    public static int BEST_SHARK = 7;
    public static int BEST_CHEST = 15;
    public static int BEST_BATTLE = 25;
    public static int BEST_BLESS = 10;
    public static int BEST_BOSS = 100;
    public static int BEST_BLACKMARKET = 0;
    public static int BEST_SHORTCUT = 10;

    //Event Percentage Bad value
    public static int BAD_UNKNOWN = 18;
    public static int BAD_OASIS = 7;
    public static int BAD_RESCUE = 10;
    public static int BAD_SHARK = 10;
    public static int BAD_CHEST = 15;
    public static int BAD_BATTLE = 30;
    public static int BAD_BLESS = 5;
    public static int BAD_BOSS = 100;
    public static int BAD_BLACKMARKET = 5;
    public static int BAD_SHORTCUT = 0;

    //Event Percentage Worst value
    public static int WORST_UNKNOWN = 16;
    public static int WORST_OASIS = 7;
    public static int WORST_RESCUE = 5;
    public static int WORST_SHARK = 10;
    public static int WORST_CHEST = 12;
    public static int WORST_BATTLE = 35;
    public static int WORST_BLESS = 5;
    public static int WORST_BOSS = 100;
    public static int WORST_BLACKMARKET = 10;
    public static int WORST_SHORTCUT = 0;

    //NPC Dialogue
    public static string[] NPCShopDialogue = {"Bueno, bonito y barato. �Me lo quitan de las manos!",
        "�Ves algo que te guste?", "Si nadie me compra, voy a tener que cerrar el chiringuito.",
        "Venga que hoy invita la casa. O no...", "Si no te gusta lo que vendo, siempre puedes montarte tu propia tienda."};

    public static string[] NPCShopBuy = { "�Gracias por su compra!", "Un placer hacer negocios con mi cliente favorito.",
    "�Ves algo m�s que sea de tu agrado?"};

    public static string[] NPCShopNoMoney = { "Si no tienes dinero para pagarlo no voy a d�rtelo �eh?", "No insistas, veo que tienes la cartera vac�a.",
    "�Por qu� no te vas a saquear otro sitio por ah�?"};

    public static string[] NPCShopGood = {"Pero qu� ven mis ojos, �si es mi cliente favorito!",
        "Hoy tenemos una oferta especial para clientes como t�, pero no vayas dici�ncolo por ah�, �eh?",
        "Lo que haces por este pueblo es incre�ble. Una rebaja es lo menos que puedo ofrecerte."};

    public static string[] NPCShopBad = {"Aqu� no eres bien recibido. Vete yendo por donde has venido.",
        "Como sigas por aqu� cerca la oferta de hoy va a ser un pu�etazo. Invita la casa.",
        "Quer�amos librarnos de los piratas, no invitarlos a nuestras casas. Vamos, �largo de aqu�!"};

    public static string[] NPCDialogue = {"Como est�n los m�quinas lo primero de todo.",
        "�ltimamente el mar se ha convertido en un sitio peligroso.",
        "Los tiempos han cambiado, este pueblo ya no es lo que era.",
        "Me cri� en este lugar, es una pena ver en lo que se ha convertido.",
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
        "La vida de cada persona es un conjunto de constantes y variables. �No es po�tico?",
        "Hace unos a�os me fastidi� el dedo m��ique, ahora uso un dedal para cubrir mi 'horrible deformidad' jajaja.",
        "Me da verg�enza hablar contigo, pero siento como si una fuerza me impulsara a hacerlo.",
        "�Puedo continuar andando? Tengo una cita y creo que voy a llegar tarde...",
        "Jurar�a que quer�a caminar en otra direcci�n, �por qu� sigo por aqu�?"};

    public static string[] NPCDialogueGood = {
        "�Eres el pirata del que habla todo el mundo? Me das un poco de miedo, pero tu eficacia es innegable...",
        "�ltimamente se ven muchas caras nuevas por aqu�... Gracias.",
        "No deber�a estar hablando contigo, pero no me pareces tan malo como se comenta por ah�.",
        "Es un secreto, pero estoy pensando en unirme a tu banda. No se lo digas a nadie, �eh?",
        "Quiz� no todos los piratas den miedo despu�s de todo.",
        "Muchas personas est�n en tu contra, pero no conozco a nadie m�s que se despierte cada d�a y luche por hacer del mundo un lugar mejor.",
        "No puedo decir que apoye tus m�todos, pero no puedo expresar con palabras la gratitud que te tengo.",
        "Supongo que hay veces en las que hay que apoyar la pirater�a, �no? No s� si termina de convencerme...",
    };

    public static string[] NPCDialogueBest = {
        "No cabe duda de que eres el m�s indicado para ser el guard�an de esta isla. No tendr�s un n�mero asociado o algo as�, �no?",
        "No me importa lo que se diga fuera de esta isla. Para m� eres el rey de los piratas.",
        "En tu honor voy a llamar Jack a mi hijo. �C�mo? �Ese no es tu nombre? Entonces lo llamar� Luffy. �Tampoco?",
        "Qui�n iba a pensar que un pirata iba a ponernos la vida m�s f�cil.",
        "�Menos mal que te has ganado el favor de esta gente! Llevo meses intentando hablar contigo, pero yo no hablo con criminales.",
        "Yo tambi�n quiero ser pirata. Pero no s� donde comprarme el loro... ni el barco. �Me prestas los tuyos?",
        "No ve�a tantas caras por el pueblo desde mi infancia. No tengo palabras para agradecerte todo lo que haces.",
        "Mi abuelo tambi�n fue un pirata muy famoso. �Te suena el nombre de Guybrush Threepwood?",
    };

    public static string[] NPCDialogueBad = {
        "No s� si va a ser peor el remedio o la enfermedad...",
        "Me est� costando mucho mantener nuestra amistad despu�s de... bueno, de tus �ltimas decisiones, en general.",
        "Le das a la gente el poder para decidir y mira lo que hacen con �l. Decepcionante.",
        "Voy a empezar a hacer lo contrario de lo que digas, porque �ltimamente no das una, �eh?",
        "La gente empieza a mirarte con malos ojos. Pero yo no s� que pensar a�n. No nos decepciones, por favor...",
        "�ltimamente me estoy sintiendo un poco mal por empezar a pensar que �ramos amigos.",
        "Espero que esto que est�s haciendo te merezca la pena.",
        "El futuro est� dejando de mostrarse esperanzador. Tus acciones tendr�n consecuencias.",
    };

    public static string[] NPCDialogueWorst = {
        "No lo intentes. No va a salir de m� ni una palabra buena hacia t�.",
        "...",
        "Me gustar�a que te alejaras de mi. Gracias.",
        "Esto era mejor cuando solo �ramos tres personas aqu�. Lo has arruinado todo.",
        "Lo que tengo que decir no es mejor que el silencio, as� que mejor me voy callando.",
        "�Por qu� no te vas por ah� a ver si te ataca un jabal� o algo?",
        "Cuando llegue tu arco de redenci�n me avisas si eso, que ahora mismo tengo mucho l�o.",
        "�Puedes hacer un favor m�s a la isla y dejar que te coma un remolino?"
    };

    public static string[] TutorialIsland1 = {
        "�GRAAAAA! Bienvenido grumete! �Es tu primera vez en esta isla?",
        "Ahora mismo te encuentras en mitad del pueblo de la ciudad. �GRA GRA!",
        "Este lugar a veces est� lleno de vida. Prueba a integrarte entablando conversaci�n con los lugare�os. �GRAAAAA!",
        "Cuando hayas terminado, te esperar� junto a la tienda del pueblo que se encuentra m�s adelante. �No tiene p�rdida! �No tiene p�rdida!"
    };

    public static string[] TutorialIsland2 = {
        "�GRAAAAA! �Qu� te est� pareciendo la isla? Interesante, �verdad?",
        "Esta es la �nica tienda que queda en el pueblo, no olvides pasarte a comprar para prepararte antes de una aventura. �GRA GRA!",
        "Ac�rcate a la due�a de la tienda y c�mprale alguna cosa, seguro que se alegra de ver clientes. �GRAAAAA!",
        "Si ya has terminado, te esperar� junto al embarcadero que hay en la playa. �No tiene p�rdida! �No tiene p�rdida!"
    };

    public static string[] TutorialIsland3 = {
        "�GRAAAAA! �Qu� te ha parecido la tendera? Es muy amable, pero cuidado. �No tolera a las malas personas! �GRAAAA!",
        "Ahora estamos en el embarcadero, desde aqu� puedes acceder a tu barco e iniciar una aventura en alta mar. �No est�s emocionado? �GRA GRAAA!",
        "Durante tu traves�a ten mucho cuidado con las decisiones que tomas. �Las noticias vuelan en este pueblo! Cada acci�n puede tener consecuencias. �GRAA!",
        "Por aqu� ya no hay mucho m�s que hacer. Ac�rcate al final del embarcadero e inicia una aventura. �GRAAAAA!"
    };

    public static string[] TutorialMap = { 
        "�GRAAAA! �Primera traves�a en alta mar, marinero?",
        "Como puedes ver, este mapa muestra los puntos de inter�s m�s destacados de esta parte del oc�ano. �GRAA!",
        "La vida pirata no es f�cil, y en cualquier momento se te puede presentar una decisi�n que tendr� consecuencias importantes...",
        "Podr�s consultar las consecuencias de tus acciones haciendo clic en el icono de 'Reputaci�n' de la esquina superior izquierda. �GRAAAAA!",
        "Adem�s, si en alg�n momento pierdes de vista tu destino, puedes pulsar la flecha de la leyenda de la esquina superior derecha...",
        "As� se desplegar� una aclaraci�n de los distintos eventos de inter�s �GRA GRA!",
        "Tambi�n puedes volver a pulsar el mismo icono para volver a plegar la leyenda �GRAAAAAAAA!",
        "Por ahora eso es todo. �GRAAAA! Prueba a hacer clic en uno de los eventos iniciales y ve haci�ndote camino entre estas peligrosas aguas. �GRA GRA!",
        "Si alguna vez necesitas que te refresque la memoria, interact�a con el icono de la esquina inferior derecha. �GRAA!",
        "Es un icono con mi cara. �No tiene p�rdida! �No tiene p�rdida! �GRAA GRAA!"
    };

    public static string[] ShortTutorialMap = {
        "Haz clic sobre un evento activo para continuar con tu aventura. �GRAAAAAAAAAA!",
        "�C�mo te has portado �ltimamente? �GRAA!\nPulsa sobre el icono de 'Reputaci�n' para analizar tu progreso. �GRA GRA!",
        "�Te has perdido?\nPulsa sobre la flecha del icono de la Leyenda para saber m�s sobre estos mares. �GRAAA!",
        "�Volver a la isla? �Para eso tienes que completar tu traves�a! �GRAA!\nO morir en el intento... �GRA GRA!",
        "Echa un ojo a tu reputaci�n de vez en cuando, estas aguas est�n repletas de aliados y enemigos, pero debes decidir c�al es cu�l. �GRAAAAA!"
    };

}

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
    public static string ESCAPE_INTERACTION = "Escape";

    //Text color
    public static int COLOR_BLACK = 0;
    public static int COLOR_GREEN = 1;
    public static int COLOR_RED = 2;

    //Reputation discount and recharge
    public static int DISCOUNT_PERCENT = 80;                                            //Percent after discount
    public static int RECHARGE_PERCENT = 120;                                           //Percent after recharge

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
    public static int EVENT_BLACKMARKET = 8;
    public static int EVENT_SHORTCUT = 9;

    //Event name
    public static string NAME_UNKNOWN = "Evento Desconocido";
    public static string NAME_BLESS = "Evento Caverna misteriosa";
    public static string NAME_CHEST = "Evento Botín pirata";
    public static string NAME_OASIS = "Evento Oasis milagroso";
    public static string NAME_SHARK = "Evento Ataque de tiburones";
    public static string NAME_RESCUE = "Evento Rescate";
    public static string NAME_BATTLE = "Evento Combate";
    public static string NAME_BOSS = "Evento Jefe Final";
    public static string NAME_BLACKMARKET = "Evento Mercado Negro";
    public static string NAME_SHORTCUT = "Evento Pasaje Corsario";

    //Event explanation
    public static string EXPLANATION_UNKNOWN = "La tripulación se ha encontrado con un evento desconocido.\nRealmente este evento invocaría a cualquiera de los otros y tendría las consecuencias del evento seleccionado de manera aleatoria.";
    public static string EXPLANATION_BLESS = "La tripulación se ha encontrado con una misteriosa caverna.\nParece que dentro se encontraba una Mesa de destilería casera, muy útil para fabricar poderosos brebajes que lanzar a tus enemigos.\nSin embargo, no está muy bien recibida entre los buenos piratas. ¿Lo recoges?";
    public static string EXPLANATION_CHEST = "¡Pero qué ven mis ojos! La tripulación se ha encontrado con un hermoso botín pirata escondido años atrás. Supongo que nadie lo echará de menos...\nLa tripulación recibe monedas de oro";
    public static string EXPLANATION_OASIS = "¡Tierra a la vista! ¿Será una agradable zona de descanso o un espejismo causado por el cansancio?\nLa tripulación descansa, recuperando parte de sus Puntos de Salud";
    public static string EXPLANATION_SHARK = "Las aguas parecen más agitadas y hostiles que de costumbre. ¡Tiburones arremeten contra el barco!\nLa tripulación pierde Puntos de Salud y monedas de oro.";
    public static string EXPLANATION_RESCUE = "¡Socorro! ¡Parece que alguien está siendo atacado por otros piratas!\n¿Debe la tripulación ir en su auxilio?";
    public static string EXPLANATION_BATTLE = "Monstruos horribles vienen al ataque. ¡Hora de pasar a la acción!";
    public static string EXPLANATION_BOSS = "Este enemigo no se parece en nada a los peligros enfrentados hasta ahora.\nSerá mejor que la tripulación se prepare...";
    public static string EXPLANATION_BLACKMARKET = "Aquí aparecérá una tienda como la de la isla principal, pero con objetos del mercado negro.";
    public static string EXPLANATION_SHORTCUT = "Los corsarios de buena reputación reconocen a la tripulación como miembros de los suyos.\nLa tripulación utiliza un pasaje secreto para evitar algunas amenazas y obtener importantes recompensas.";

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
    public static string[] NPCShopDialogue = {"Bueno, bonito y barato. ¡Me lo quitan de las manos!",
        "¿Ves algo que te guste?", "Si nadie me compra, voy a tener que cerrar el chiringuito.",
        "Venga que hoy invita la casa. O no...", "Si no te gusta lo que vendo, siempre puedes montarte tu propia tienda."};

    public static string[] NPCShopBuy = { "¡Gracias por su compra!", "Un placer hacer negocios con mi cliente favorito.",
    "¿Ves algo más que sea de tu agrado?"};

    public static string[] NPCShopNoMoney = { "Si no tienes dinero para pagarlo no voy a dártelo ¿eh?", "No insistas, veo que tienes la cartera vacía.",
    "¿Por qué no te vas a saquear otro sitio por ahí?"};

    public static string[] NPCShopGood = {"Pero qué ven mis ojos, ¡si es mi cliente favorito!",
        "Hoy tenemos una oferta especial para clientes como tú, pero no vayas diciéncolo por ahí, ¿eh?",
        "Lo que haces por este pueblo es increíble. Una rebaja es lo menos que puedo ofrecerte."};

    public static string[] NPCShopBad = {"Aquí no eres bien recibido. Vete yendo por donde has venido.",
        "Como sigas por aquí cerca la oferta de hoy va a ser un puñetazo. Invita la casa.",
        "Queríamos librarnos de los piratas, no invitarlos a nuestras casas. Vamos, ¡largo de aquí!"};

    public static string[] NPCDialogue = {"Como están los máquinas lo primero de todo.",
        "Últimamente el mar se ha convertido en un sitio peligroso.",
        "Los tiempos han cambiado, este pueblo ya no es lo que era.",
        "Me crié en este lugar, es una pena ver en lo que se ha convertido.",
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
        "La vida de cada persona es un conjunto de constantes y variables. ¿No es poético?",
        "Hace unos años me fastidié el dedo méñique, ahora uso un dedal para cubrir mi 'horrible deformidad' jajaja.",
        "Me da vergüenza hablar contigo, pero siento como si una fuerza me impulsara a hacerlo.",
        "¿Puedo continuar andando? Tengo una cita y creo que voy a llegar tarde...",
        "Juraría que quería caminar en otra dirección, ¿por qué sigo por aquí?"};

    public static string[] NPCDialogueGood = {
        "¿Eres el pirata del que habla todo el mundo? Me das un poco de miedo, pero tu eficacia es innegable...",
        "Últimamente se ven muchas caras nuevas por aquí... Gracias.",
        "No debería estar hablando contigo, pero no me pareces tan malo como se comenta por ahí.",
        "Es un secreto, pero estoy pensando en unirme a tu banda. No se lo digas a nadie, ¿eh?",
        "Quizá no todos los piratas den miedo después de todo.",
        "Muchas personas están en tu contra, pero no conozco a nadie más que se despierte cada día y luche por hacer del mundo un lugar mejor.",
        "No puedo decir que apoye tus métodos, pero no puedo expresar con palabras la gratitud que te tengo.",
        "Supongo que hay veces en las que hay que apoyar la piratería, ¿no? No sé si termina de convencerme...",
    };

    public static string[] NPCDialogueBest = {
        "No cabe duda de que eres el más indicado para ser el guardían de esta isla. No tendrás un número asociado o algo así, ¿no?",
        "No me importa lo que se diga fuera de esta isla. Para mí eres el rey de los piratas.",
        "En tu honor voy a llamar Jack a mi hijo. ¿Cómo? ¿Ese no es tu nombre? Entonces lo llamaré Luffy. ¿Tampoco?",
        "Quién iba a pensar que un pirata iba a ponernos la vida más fácil.",
        "¡Menos mal que te has ganado el favor de esta gente! Llevo meses intentando hablar contigo, pero yo no hablo con criminales.",
        "Yo también quiero ser pirata. Pero no sé donde comprarme el loro... ni el barco. ¿Me prestas los tuyos?",
        "No veía tantas caras por el pueblo desde mi infancia. No tengo palabras para agradecerte todo lo que haces.",
        "Mi abuelo también fue un pirata muy famoso. ¿Te suena el nombre de Guybrush Threepwood?",
    };

    public static string[] NPCDialogueBad = {
        "No sé si va a ser peor el remedio o la enfermedad...",
        "Me está costando mucho mantener nuestra amistad después de... bueno, de tus últimas decisiones, en general.",
        "Le das a la gente el poder para decidir y mira lo que hacen con él. Decepcionante.",
        "Voy a empezar a hacer lo contrario de lo que digas, porque últimamente no das una, ¿eh?",
        "La gente empieza a mirarte con malos ojos. Pero yo no sé que pensar aún. No nos decepciones, por favor...",
        "Últimamente me estoy sintiendo un poco mal por empezar a pensar que éramos amigos.",
        "Espero que esto que estás haciendo te merezca la pena.",
        "El futuro está dejando de mostrarse esperanzador. Tus acciones tendrán consecuencias.",
    };

    public static string[] NPCDialogueWorst = {
        "No lo intentes. No va a salir de mí ni una palabra buena hacia tí.",
        "...",
        "Me gustaría que te alejaras de mi. Gracias.",
        "Esto era mejor cuando solo éramos tres personas aquí. Lo has arruinado todo.",
        "Lo que tengo que decir no es mejor que el silencio, así que mejor me voy callando.",
        "¿Por qué no te vas por ahí a ver si te ataca un jabalí o algo?",
        "Cuando llegue tu arco de redención me avisas si eso, que ahora mismo tengo mucho lío.",
        "¿Puedes hacer un favor más a la isla y dejar que te coma un remolino?"
    };

    public static string[] NPCPiratePierIntro = {
        "¡Pero qué ven mis ojos! ¿Un nuevo pirata por aquí?",
        "Estas aguas son peligrosas. Si quieres zarpar hacia la aventura, vas a necesitar un buen barco y un mapa.",
        "¿Por qué no preguntas a mis hermanos? Seguro que están encantados de ayudar a alguien del gremio",
        "Busca a un par de piratas por esta isla y pregunta sobre un mapa o un barco, ¿quieres?"
    };

    public static string[] NPCPiratePierSearch = {
        "Veo que traes un mapa. ¡Bien hecho! Pero sin barco aún no puedes zarpar. ¿Has visto a mi otro hermano?",
        "¿Te ha prestado el barco?. ¡Bien hecho! Pero sin mapa aún no puedes zarpar. ¿Has visto a mi otro hermano?"
    };

    public static string[] NPCPiratePierFinal = {
        "¡Viento en popa a toda vela! ¿Quieres que te acerque el barco para navegar?"
    };

    public static string[] NPCPirateMap = {
        "Debería deshacerme ya de este viejo mapa...",
        "¿Un mapa? Has hablado con mi hermano, ¿verdad? Si lo quieres es todo tuyo. Pero no admito devoluciones. ¡Estás avisado!",
        "Ha pasado por momentos mejores, pero ese viejo mapa te guiará por todo el océano, trátalo bien."
    };

    public static string[] NPCPirateBoat = {
        "Es una pena que nadie use ya el viejo barco...",
        "¿Un barco? Has hablado con mi hermano, ¿verdad? Si lo quieres es todo tuyo. Pero no admito devoluciones. ¡Estás avisado!",
        "Ya no se hacen barcos así, más te vale no hacerle ni un rasguño."
    };

    public static string[] TutorialIsland1 = {
        "¡GRAAAAA! ¡Bienvenido grumete! ¿Es tu primera vez en esta isla?",
        "¿Por qué no investigas un poco? ¡GRAAAAA! Yo te esperaré junto a la tienda del pueblo que se encuentra más adelante. ¡No tiene pérdida!"
    };

    public static string[] TutorialIsland2 = {
        "¡GRAAAAA! ¡Hola de nuevo! Esta es la única tienda que queda en el pueblo, aquí puedes hacer tus compras antes de una aventura. ¡GRA GRA!",
        "Hablando de aventuras, ¿has pasado ya por el embarcadero que hay en la playa? ¡No te lo puedes perder! ¡GRAAAA!"
    };

    public static string[] TutorialIsland3 = {
        "¡GRAAAA! El embarcadero solía ser un punto de interés entre los marineros, pero ahora solo lo visitan unos pocos ex piratas",
        "¿Por qué no pruebas a pedirle consejo a alguno de ellos? ¡Cualquier información puede ser vital! ¡GRA GRA!",
        "¡Ánimo! Las aventuras en alta mar son lo mejor ¡GRAAAAAAA!"
    };

    public static string[] TutorialMap = { 
        "¡GRAAAA! Primera travesía en alta mar. ¿No estás emocionado?",
        "El mapa que te han entregado es increíble, muestra todos los puntos de interés del océano. ¡GRAA!",
        "¡Incluso tiene una leyenda para que no te pierdas! ¿Por qué no pruebas a interactuar con ella! ¡GRA GRA!",
        "¡Cuidado! Algunos puntos pueden requerir decisiones morales. Para consultar tu nivel de reputación haz clic en el icono de 'Reputación'. ¡GRAAAAA!",
        "Si alguna vez necesitas que te refresque la memoria, interactúa con mi icono. ¡No tiene pérdida! ¡GRA GRA!",
    };

    public static string[] ShortTutorialMap = {
        "Haz clic sobre un evento activo para continuar con tu aventura. ¡GRAAAAAAAAAA!",
        "¿Cómo te has portado últimamente? ¡GRAA!\nPulsa sobre el icono de 'Reputación' para analizar tu progreso. ¡GRA GRA!",
        "¿Te has perdido?\nPulsa sobre la flecha del icono de la Leyenda para saber más sobre estos mares. ¡GRAAA!",
        "¿Volver a la isla? ¡Para eso tienes que completar tu travesía! ¡GRAA!\nO morir en el intento... ¡GRA GRA!",
        "Echa un ojo a tu reputación de vez en cuando, estas aguas están repletas de aliados y enemigos, pero debes decidir cúal es cuál. ¡GRAAAAA!"
    };

}

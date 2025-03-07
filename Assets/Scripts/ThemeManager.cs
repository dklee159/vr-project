using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using UnityEngine;
using UnityEngine.Video;

public class ThemeManager : MonoBehaviour
{
    // public static ThemeManager instance;
    private string season = "None";
    public string Season {get { return season;} set { 
        season = value;
        changeSound(season);
        setMediaArtHall(season);
        ChangePaintingMats(season);
        ChangeDescription(season);
    }}

    [SerializeField] Canvas hoverCanvas;
    [SerializeField] Canvas seaonsCanvas;
    [SerializeField] List<Material> springMats;
    [SerializeField] List<Material> summerMats;
    [SerializeField] List<Material> autumnMats;
    [SerializeField] List<Material> winterMats;
    [SerializeField] List<GameObject> paintings;

    [SerializeField] GameObject springSeason;
    [SerializeField] GameObject summerSeason;
    [SerializeField] GameObject autumnSeason;
    [SerializeField] GameObject winterSeason;
    [SerializeField] List<AudioClip> classicMusic;
    [SerializeField] List<GameObject> uiLists;
    [SerializeField] List<GameObject> mediaArtWall;
    [SerializeField] List<VideoClip> springMedia;
    [SerializeField] List<VideoClip> summerMedia;
    [SerializeField] List<VideoClip> autumnMedia;
    [SerializeField] List<VideoClip> winterMedia;

    private Vector3 descriptionOffset = new Vector3(0, 1.2f, 0);
    private bool isHover = false;

    string[] springDescription = {
        "르느와르 - 봄화병\n1866년 르누아르는 봄을 표현하기 위해 꽃병속에 봄을 담는다는 생각으로 봄꽃을 여럿 준비하여 꽃병을 만들어 정물화를 그리기 시작한다. 추운겨울을 지나 여러 꽃들을 표현하여 봄이 왔음을 알리는 작품인 느낌을 받게 된다. 한 종류의 꽃이 아닌 여러 종류의 꽃이 있는 것은 다양한 봄의 느낌을 표현하는 르누아르만의 감성적 부분으로 보인다.",
        "마네 - 봄\n에두아르 마네의 작품 '봄'은 파리의 여배우 잔 드마르시를 통해 눈부시게 사랑스럽고 싱그러운 아름다움을 표현하는데요. 무성한 나뭇잎과 푸른 하늘을 배경으로 파라솔과 꽃무늬 드레스를 입은 여인을 봄의 화신으로 화사함을 묘사하고 있습니다.",
        "모네 - 센강의 봄\n파리 북서쪽, 센 강이 영해로 향하는 곳에는 앙 크리아트 섬이 위치하고 있습니다. 이곳은 중간에 위치한 모래 언덕의 섬입니다. 파리 시민들은 일요일에 이곳을 산책하며, 예술사에서는 조르주 쇠라의 그림 '그랑 자트 섬의 일요일' (1884-86)에서 가장 친숙한 장소입니다. 그러나 인상주의 화가들도 이 섬에서 활동했으며, 클로드 모네는 1878년 봄 하루 화창한 날에 이곳에 그의 그림 풍경을 그렸습니다. 그는 보통 아르장티유의 아름다운 풍경을 선호했지만, 이번에는 그랑 자트에서 그릴 모티브를 찾았습니다. 이 그림에는 봄의 푸른 잎과 넓은 하늘이 보여집니다. 오른쪽에는 르발루아의 강둑이 있고, 직진하면 아시에르를 향한 철도 다리가 있습니다(나무 사이로 모네가 볼 수 있었습니다). 아주 뒷 배경에는 클리시의 새 가스 공장의 높은 굴뚝이 나타나 있습니다. 이것은 하얀 구름과 섞이는 검은 연기를 내뿜었습니다. 모네는 이 모티브에 대해 세 개의 유사한 버전을 만들었지만, 그림은 똑같지 않았습니다. ",
        "밀레 - 봄\n밀레가 표현한 봄 풍경은 무조건 화사하지도, 매우 밝지만도 않아요. 그의 그림 한편에는 어둠이 있고, 소나기가 지나간 흔적도 있어요. 모두에게 오늘이 봄일 수 없고 모두에게 오늘이 화창할 수 없죠. 봄 이라는 계절 안에도 꽃샘추위가 있고, 봄비가 있고, 소나기가 있고, 먼지가 날리는 날씨가 있듯이 우리 삶의 계절 역시 그럴거에요. 하루하루 봄을 느끼지 못하더라도 지나고 보면 ‘아 그때가 봄이었구나.' 떠올릴 수 있었으면 좋겠어요.프레데릭 하트만은 사실 처음에는 밀레가 아닌 테오도르 루소에게 사계절 연작을 주문합니다. 하지만 우연치 않게 화가 테오도르 루소가 그림을 완성하지 못한 채 세상을 떠나자 밀레에게 다시 주문을 하죠.밀레의 사계절 연작 중 <봄> 을 그린 이 작품 속에는 오솔길을 따라가 보면 왼편에는 꽃이 만발한 사과나무와 채소밭이, 그리고 이제 막 기지개를 피려는 들꽃들이 보입니다. 지나가던 농부는 갑자기 내린 소나기를 피해 나무 밑에 있어요. 있는 그대로의 농촌 풍경을 묵묵히 담아낸 그의 그림에서 우리는 다양한 봄의 시간을 만날 수 있어요.",
        "빌 헬름 리스트 - 목련\n리스트는 호수와 후경의 나무 부분을 섬세한 디테일로 묘사하고 있다. 또 물가에 그려 넣은 잔디는 반 고흐의 터치를 연상시킨다. 그러나 여기서 가장 정교한 세부묘사를 보여주는 것은 목련나무 자체이다. 마치 우리가 손을 뻗어 꽃 한 송이를 꺾을 수 있을 것 같은 착각을 일으킬 만큼, 나무는 생생하게 표현되어 있다. 또 여기에는 인상주의적인 느낌도 발견되는데, 만약 호수 위에 몇 개의 수련이 떠있다면, 이 그림은 모네의 작품과 흡사해 보일 것이다.",
        "쇠라 - 그랑드 자트섬의센강,봄\n쇠라의 작품 가운데서도 강변과 해안 풍경이 적지 않다. <그랑드 자트 섬의 일요일 오후>에서 보는 시각에서 강 쪽으로 더욱 나간 장면이고, 화면의 중심은 강에 떠 있는 돛배와 카누에 있다. 원경의 해안의 수평선과 근경의 둑이 보여 주는 사선은 쇠라의 풍경화에서는 자주 나타나는 구도인데, 수평과 수직, 그리고 사선을 통한 긴밀한 화면의 밀도를 엿볼 수 있다. 점묘는 더욱 세분 화되어 마치 상감(象嵌)을 하듯 색채를 조탁(彫琢)해 넣었다. 화창한 봄날의 신록과 빛나는 강 물, 그리고 흰 돛의 조화는 풍부한 계절감을 여실히 드러내고 있다.",
        "시슬레 - 과수원의 봄\n알프레드 시슬리는 영국계 화가였습니다. 그는 고향인 베뇌 나돈과 폰텐블로 숲 근처인 바이 마을 바깥의 과수원을 그렸습니다. 시슬리는 자신의 주변의 아름다움에 열정적이었습니다. 친구에게 쓴 편지에서 그는 자신이 그린 모든 그림이 자신이 사랑에 빠진 장소를 묘사했다고 말했습니다. 그는 강변과 로와 세인 강변의 경치를 담은 여러 풍경화를 제작했습니다. 대부분의 인상주의 화가와 달리, 시슬리는 거의 인물을 묘사하지 않았으며, 인물을 묘사할 때에도 그들은 풍경에 후순위로 배치되었습니다. 이 그림에서 볼 수 있는 인물들은 개별적인 캐릭터가 아니라 나무가 우거진 둑에 흥미를 더하는 데 그쳤습니다.",
        "이중섭 - 벚꽃 위의 새\n복사꽃이 만발한 가지에 흰 비둘기가 사뿐히 내려앉자, 꽃잎이 땅으로 우수수 떨어지는 장면을 스틸로 포착한 그림이다. 꽃가지가 출렁이자 가지 안쪽에 앉아 있던 청개구리 한 마리가 놀라 움츠린 표정을 짓는다. 그 위로 나비 한 마리가 날아오르는 장면은 마치 옛 그림의 화조화를 현대 감성으로 재해석한 듯한 구성미를 보여준다. 배경의 붓질은 여전히 거칠지만, 찬바람을 물리친 봄의 따스한 서정이 화면 가득하다. 유난히 생명이 충만한 봄내음을 가득 담은 유화 그림이다",
    };

    string[] summerDescription = {
        "고흐 - 생트 마리 드라메르의 바다 풍경\n생트마리 해안은 고흐에게 많은 영감을 준 곳입니다.정신질환의 요양을 위해 아를르에 머무르면서 아름다운 바다풍경에 매료된 그는 매일 아침 일찍 해변에 나가 고기잡이배들의 풍경을 그리기를 즐겼다고 하는데요. 그 연작들 중 하나인 위 작품은 고흐 특유의 채색법이 돋보이는 작품으로 일렁이는 파도를 표현하기 위해 파란색과 흰색의 대비를 강조하면서 녹색과 노란색을 더해 생동감을 주었습니다.",
        "르느와르 - 여름풍경\n이 그림은 르느와르가 1873년에 그린 것으로 추정되는 작품으로 원제는 'Woman with a Parasol in a Garden'이다. 작품명처럼 화사한 꽃이 만발한 정원을 걷는 양산을 쓴 여성이 눈에 띄며 짙은 녹색의 배경과 대조되는 색상을 사용하여 꽃의 붉고 하얀 부분이 강조되어 보이는 인상파의 한 형태를 볼 수 있다.",
        "마네 - 뱃놀이\n배 위의 느긋한 시간. 견습 선원을 하기도 했던 마네는 해양과 관련된 작품들을 많이 남겼습니다. 안정적이지 않은 구도가 특징으로, 보는 사람이 마치 함께 배에 타고 있는 듯한 시각적 효과를 불러옵니다.",
        "모네 - 베네티유의 여름\n파리 서북쪽 센강둑에 위치한 베네티유는 빛의 화가 모네가 아흐정뙤이 에서 지베르니로 이주하기 전 머물던 곳, 싱그러움을 잔뜩 머금은 나무와 푸른하늘, 그 한ㄹ을 모방한 듯한 강, 수면에 비친 평화로운 자연 풍경은 더위마저 시원하게 달래준다. 바람에 일렁이는 물의 찰랑거림까지도 생생하게 전해지는 베르티유의 경관은 그야말로 아름답다.",
        "샤갈 - 한 여름밤의 꿈\n러시아 출신 프랑스 화가 마르크 샤갈의 1939년 작 ‘한여름 밤의 꿈’은 신비로움으로 가득 찬 그림이다. 윌리엄 셰익스피어의 낭만 희극 ‘한여름 밤의 꿈’을 모티브로 했다. 희곡 ‘한여름 밤의 꿈’은 아테네 공작인 테세우스와 히폴리타의 혼례를 나흘 앞둔 어느 여름밤, 혼례를 축하하는 연극 연습이 한창이던 마법의 숲에 있던 세 쌍의 남녀에게 찾아온 백일몽을 그린 작품이다.",
        "조르주 쇠라 - 아스니에르에서의 물놀이\n여름날 강에서 물놀이를 하며 쉬고 있는 사람들의 모습을 담았다. 물에서 수영을 하거나 강가에서 편하게 쉬는 사람들의 모습에서 한가롭고 여유로운 느낌이 든다. 햇빛에 따라 변하는 자연의 색채를 물감을 찍어 점으로 표현했다. 쇠라가 처음으로 점묘법을 실험한 작품이다.",
        "아르침볼도 - 여름\n아르침볼도가 1573년 막시밀리안 2세(재위 1564~1575)의 주문을 받아 그린 ‘여름’은 그가 평생 여러 차례 그린 바 있던 사계절 연작에 속하는 그림이다. 사계절 연작은 당시 엄청난 인기를 끌었던 주제였다.1562년 아르침볼도가 사계절 연작을 처음으로 그렸을 때, 사람들은 과일과 야채를 모아 사람의 머리를 만들어 낸 상상력에 열광했다. 그는 계속해서 이 주제를 발전시켜 나갔는데, 이는 여러 가지 점으로 보아 자신의 시대를 몇 세기 앞서간 것이었다.",
        "호아킨 소로야 - 바닷가의 산책\n그의 작품은 순간적인 자유분방한 붓 터치로 자연의 빛이 빚어낸 시적인 분위기를 캔버스에 담아낸다. 사실적으로 표현한 벨라스케스 인물 표현 방법과 빛을 회화로 표현하는 모네의 영향을 받아 그는 새로운 화풍을 구축했고 자신만의 그림을 그려나갔다. 소로야는 빛이 많을수록 그림은 더 생기롭고 진실하며 아름답다고 여겼다. 그는 빛의 본질에 다가가기 위해 한낮에 화구와 캔버스를 들고 해변으로 나와, 눈앞에 펼쳐진 광경을 재빨리 그림으로 눈부시고 아름답게 묘사했다.",
    };

    string[] autumnDescription = {
        "고흐 - 라크로의 추수\n밝은 가을햇살 아래 넓은 황금물결을 이루고 있는 밀밭의 풍경을 고흐 특유의 거친 터치로 화사하고 아릅답게 그린 작품으로 넓은 밀밭의 수평구조를 베이스로 수직으로 자란 밀대와 짚울타리의 대조를 나타내었고, 광할하게 펼쳐진 밭을 넘어 산까지 이어지는 경치를 이용하여 원금감을 나타내어 그림자체에 안정적인 느낌을 주고 있습니다.",
        "고흐 - 알리스캉의 가로수길\n1888년 프랑스 아를에서 그린 이 작품은 포플러와 석관이 늘어선 아를의 고대 로마 묘지인 알리스캉(Alyscamps)의 가을 풍경을 묘사하고 있습니다",
        "김홍도 - 타작\n이 그림에는 잘 익은 곡식을 거두어들인 후, 열심히 낟알을 떨어내고 있는 사람들의 모습이 매우 사실적으로 표현되어 있다. 지게로 벼를 잔뜩 져 나르는 사람, 가져온 볏단을 개상이라고 부르는 긴 통나무 위로 메어쳐서 이삭을 털어내고 있는 사람들, 땅에 떨어진 낟알을 빗자루로 쓸어 모으는 사람 등, 모두 여섯 명의 일꾼들이 등장하는데, 이들은 하나같이 열심히 일을 하고 있다.",
        "모네 - 아르장퇴유의 가을\n1873년 완성한 ‘아르장퇴유의 가을’은 작은 마을을 휘감고 도는 센 강변의 가을 여정을 잡아낸 인상주의 회화의 대표작이다. 센강 양옆으로 붉고 노랗게 물든 나무를 그리고 위쪽에 하늘과 구름, 전통 가옥, 성당을 배치했다. 센강 수면에 드리운 나무들이 햇빛에 부서지며 가을색의 찬란하고 순간적인 인상을 전해준다. 모네는 그림의 주제보다는 변화하는 자연을 어떻게 그릴 것인가에 주안점을 뒀다. 풍경의 순간적 인상을 포착하는 것에 관심을 뒀던 거장의 관록과 기량을 엿볼 수 있다.",
        "밀레 - 이삭 줍는 여인들\n이 작품은 얼핏보면 농촌의 목가적이고 평화로운 풍경을 그린 그림으로 보이지만, 19세기 파리 외곽 바르비종 마을에서 힘들게 살아가는 농부들의 모습을 담담하고 솔직하게 그린 '사실주의' 그림입니다. 우측 지평선에 보이는 말을 탄 남자는 당국의 관리인으로 땅에 떨어진 낟알조차도 당국과 지주의 허가와 감시를 받아 주울수있었다고 하며, 좌측의 산처럼 봉긋한 것은 수확한 건초더미 입니다. 저렇게 큰 건초더미가 있지만, 빈농들은 땅에 떨어진 낟알조차 허가를 받아야 했던 것이죠.",
        "밀레이 - 가을 낙엽\n밀레이는 가을 특유의 쓸쓸한 분위기를 좋아했다. 낙엽 타는 냄새를 특히 좋아해 ‘지나간 여름의 향내’라는 이름을 붙이고 작품의 소재로 즐겨 삼았다. 이 작품에서 낙엽 더미를 둘러싼 소녀들이 각기 짓는 표정은 삶과 죽음을 대하는 저마다의 태도를 상징한다. 왼쪽 끝의 소녀는 낙엽 태우는 일에 관심이 없다는 듯한 표정을 짓고 있고, 그 오른쪽에 있는 소녀는 움켜쥔 낙엽을 더미 위에 올려놓고 있으면서도 이를 애써 외면하는 듯하다. 그 옆의 소녀는 명상하듯 눈을 감고 있고, 손에 과일을 든 소녀는 낙엽더미를 무심하게 바라보고 있다. 그림은 소녀와 낙엽이라는 서로 대비되는 소재를 통해 모든 것에는 끝이 있다는 평범한 진리를 세련되게 드러내고 있다.",
        "아르침볼도 - 가을\n이 작품은 공정화가로 활동할 당시 프라하 궁정에서 황제의 초상을 그린작품으로, 각 계절에 맞는 동식물로 사계절을 표현한 작품 중 '가을' 입니다. 지금 시대에서 작품을 보아도 일반적인 초상과 달리 독특한 방식으로 보이는데 그 당시에는 파격적인 발상이어서 모두를 놀라게 했죠. 과일과 채소들의 배치가 잘 되어 실제 사람과 같은 모습을 하고 있는 이 작품은 자연에 대한 관찰 없이는 불가능할 만큼 각 과일과 채소들의 특징을 활용하여 초상을 그려냈습니다.",
        "윈슬로 호머 - 가을 나무\n캔버스에 브러시와 오일페인트, 전경에 나무 끝을 보여주는 전망, 일부는 가을 단풍이며, 계곡과 중간 산 사이에 회색빛 언덕의 범위가 있습니다.",
    };

    string[] winterDescription = {
        "고야 - 겨울바람\n스페인 국왕 카를로스 4세가 군림한 시절에 그린 ‘겨울바람’은 거센 눈바람 속에 농부, 군인, 사냥꾼이 살을 에는 것 같은 겨울바람을 정면으로 맞으며 힘겹게 걷는 모습을 사실적으로 표현했다. 도포를 뒤집어쓰고 한기를 막아보려 하지만 비집고 들어오는 겨울바람의 기세에 눌린 이들의 얼굴에서는 고통스러운 삶의 무게를 느낄 수 있다.",
        "모네 - 까치\n1860-70년 사이에 눈 덮인 시골 풍경을 그리는 것이 유행하였는데, 다른 화가들은 시골의 황량함과 적막감에 관심을 갖는단다. 하지만, ‘모네’의 이 작품에는 흰색의 다양함과 세부 묘사를 통하여 생기가 넘치고 햇빛이 반사되는 아름다운 풍경을 화폭에 담았다.",
        "모네 - 뵈테유 부근의 유빙\n빛의 변화를 포착하고자 했던 클로드 모네의 작품이다. 베퇴유의 겨울을 그린 베퇴유 부근의 유빙 아르장퇴유에엇 가족과 행복하게 보냈던 때와는 달리, 이 시기 모네는 경제적으로 어려웠을 뿐만 아니라 아내 카미유까지 급격히 건강이 악화되다 결국 사망하고야 만다. 정서적으로 매우 힘든상황을 겪고 있었을 모네. 아르장퇴유에서의 행복했던 시간 속에서 그렸던 사랑스럽고 따뜻한 봄과는 대조적으로, 베퇴유에서의 작품은 모네의 마음을 보여주기라도 하듯 혹한기 겨울의 축축함과 얼음의 날카로움을 담고 있는 것만 같다.",
        "브뢰헬 - 눈속의 사냥꾼\n당시 유럽에는 이상기후로 인한 한파가 기승을 부렸다. 특히 플랑드르는 정치적으로도 혹독한 계절을 지나고 있었다. 네덜란드에 침입한 스페인의 펠리페 2세가 주민들을 가톨릭으로 개종시키기 위해 온갖 압박을 가했다. 그런데도 사람들은 좌절하지 않았다. 그림 속 민초들의 활기찬 일상이 팬데믹과 추위에도 굴하지 않고 하루하루 충실하게 살아가는 우리네 모습과 겹쳐 보인다.",
        "시슬레 - 루브시엔의 눈\n루브시엔느의 눈 내린 풍경을 그린 이 그림은 또한 새롭게 해석되는 시슬레 만의 원근법이 나타난다. 눈이 내린 거리의 길이 끝나는 부분에 서 있는 사람은 자연 속에서 왠지 혼자 단절된 것만 같다. 이 대비는 미묘하게 조화를 이루게 되는데, 통일된 색깔의 모습에 더해서 세련된 변주를 보는 것처럼 연출되어 있으며, 언뜻 평면적으로 보일 수 있는 인상파 식의 그림에 공간감을 더해준다.",
        "카유보트 - 눈 내린 지붕\n이작품은 1878년에 그린 작품으로, 카유보트가 파리의 그의 자택의 창문에서 본 겨울 풍경을 담은 것입니다. 이 작품은 당시 파리의 도시 풍경과 인프라를 반영하고 있으며, 그의 특유의 관찰력과 정확한 기술로 묘사되어 있습니다. 작품의 주요 특징 중 하나는 눈이 내린 풍경을 실감나게 표현한 것입니다.",
        "터너 - 눈보라\n터너가 77세에 완성한 ‘눈보라’는 날씨를 새로운 심미안으로 바라본 걸작이다. 눈발이 휘몰아치는 바다 위에 떠 있는 작은 증기선 한 척을 드라마틱하게 묘사했다. 거센 폭풍과 파도가 곧 배를 집어삼킬 것 같은 급박한 상황을 거칠고 재빠른 붓질로 생생하게 전해준다. 터너는 당시 네 시간 동안 돛대에 몸을 묶은 채 거친 파도를 직접 체험한 뒤 그림을 그린 것으로 알려졌다. 폭풍과 파도, 휘몰아치는 비바람, 위태로운 배 등을 효과적으로 표현하기 위해 ‘소용돌이 구도’를 사용했다.",
        "히로시게 - 간바라의 밤눈\n히로시게는 1832년에 공적 업무를 하는 관리 수행원들을 따라 에도에서 교토 사이의 도카이도 지역을 여행할 기회가 생겼다. 도중에 역참에 묵을 때마다 그는 눈으로 봤던 경관을 스케치해뒀고, 여행을 마치고 돌아온 후 <도카이도 53역참>이라는 판화집을 제작했다. 이 연작은 53개 역참의 풍경과 더불어 출발지와 도착지 장면까지 합해 총 55점으로 이뤄져 있다. ‘간바라의 밤눈’도 그중 하나다. 히로시게 그림만의 시적인 분위기와 대담한 구도, 그리고 색과 선의 독특한 기법은 유럽 인상주의 화가들의 시선을 사로잡았고 서양 미술계에 신선한 충격을 주었다. 대표적인 예로 빈센트 반 고흐는 히로시게의 판화 몇점을 그대로 유화로 모작하기도 했다.",
    };

    string[] descriptions = new string[8];
    Dictionary<GameObject, string> connectedDescriptions = new Dictionary<GameObject, string>();

    private enum Mat { 
        SPRING = 1,
        SUMMER = 2,
        AUTUMN = 3,
        WINTER = 4
    };

    // private Mat mat = Mat.SPRING;

    // private void Start() {
    // }

    void changeSound(string _season) {
        if (_season != null) {
            AudioManager.instance.AllStop();
            AudioManager.instance.Play("Vivaldi_" + _season);
        }
    }

    void setMediaArtHall(string _season) {
        if (_season != null) {    
            List<VideoClip> mediaClips = null;
            if (_season == "Spring") {
                mediaClips = springMedia;
            } else if (_season == "Summer") {
                mediaClips = summerMedia;
            } else if (_season == "Autumn") {
                mediaClips = autumnMedia;
            } else if (_season == "Winter") {
                mediaClips = winterMedia;
            }

            if (mediaClips != null) {
                for (int i = 0; i < mediaArtWall.Count; i++)
                {
                VideoPlayer videoPlayer = mediaArtWall[i].GetComponent<VideoPlayer>();                
                    // VideoPlayer가 있다면 clip 할당
                    if (videoPlayer != null && i < mediaClips.Count) {
                        videoPlayer.clip = mediaClips[i];
                    } else {
                        Debug.LogWarning("VideoPlayer or VideoClip not found for GameObject at index " + i);
                    }
                }
            } else {
                Debug.LogWarning("Invalid Season: " + _season);
            }
        }
    }

    public void PlayMedia() {
        foreach (GameObject wall in mediaArtWall) {
            wall.GetComponent<VideoPlayer>().Play();
        }
        AudioManager.instance.Pause();
        AudioManager.instance.Play("MediaArt_"+season);
    }

    public void StopMedia() {
        foreach (GameObject wall in mediaArtWall) {
            wall.GetComponent<VideoPlayer>().Stop();
            wall.GetComponent<VideoPlayer>().clip = null;
        }

        AudioManager.instance.AllStop();
        AudioManager.instance.UnPause();
    }

    private void ChangeDescription(string _season) {
        switch (_season) {
            case "Spring":
                descriptions = springDescription;
                break;
            case "Summer":
                descriptions = summerDescription;
                break;
            case "Autumn":
                descriptions = autumnDescription;
                break;
            case "Winter":
                descriptions = winterDescription;
                break;
            default:
                descriptions = springDescription;
                break;
        }

        for (int i = 0; i < paintings.Count; i++) {
            if (connectedDescriptions.ContainsKey(paintings[i])) {
                connectedDescriptions[paintings[i]] = descriptions[i];
            }
            else {
                connectedDescriptions.Add(paintings[i], descriptions[i]);
            }
        }
    }


    private void ChangePaintingMats(string _season) {
        List<Material> mats = new List<Material>();

        switch (_season) {
            case "Spring":
                mats = springMats;
                break;
            case "Summer":
                mats = summerMats;
                break;
            case "Autumn":
                mats = autumnMats;
                break;
            case "Winter":
                mats = winterMats;
                break;
            default:
                break;
        }

        for (int i = 0; i < mats.Count; i++) {
            paintings[i].GetComponent<MeshRenderer>().material = mats[i];
        }
    }

    

    public void openUI(string season) {
        for (int i = 0; i < uiLists.Count; i++)
        {
            if (uiLists[i].name == season) {
                uiLists[i].SetActive(true);
            } else {
                uiLists[i].SetActive(false);
            }
        }
    }


    // public void ChangeSeason(string season) {
    //     switch (season) {
    //         case "Spring":
    //             mat = Mat.SPRING;
    //             break;
    //         case "Summer":
    //             mat = Mat.SUMMER;
    //             break;
    //         case "Autumn":
    //             mat = Mat.AUTUMN;
    //             break;
    //         case "Winter":
    //             mat = Mat.WINTER;
    //             break;
    //         default:
    //             break;
    //     }

    //     ChangeDescription(mat);
    //     ChangePaintingMats(mat);
    // }

    public void HoverEnteredEvent(HoverEnterEventArgs args) {
        if (isHover) return;
        isHover = true;
        Vector3 interactorPos = args.interactorObject.transform.position;
        Vector3 pos = args.interactableObject.transform.position;
        Vector3 dir = (pos - interactorPos).normalized;

        hoverCanvas.enabled = true;
        hoverCanvas.transform.position = pos + descriptionOffset - dir;
        hoverCanvas.GetComponentInChildren<Text>().text = connectedDescriptions[args.interactableObject.transform.gameObject];
        Quaternion lookAt = Quaternion.identity;
        lookAt.SetLookRotation(dir);
        hoverCanvas.transform.rotation = lookAt;
    }

    public void HoverExitedEvent(HoverExitEventArgs args) {
        isHover = false;
        hoverCanvas.enabled = false;
    }
}

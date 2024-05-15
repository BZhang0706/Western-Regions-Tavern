-> Start

=== Start ===

传说在西域有一位真正的厨艺大师，没人知道他从何处来，他来到这个镇子，将人生百味炒入锅中，在西域人人敬仰，他开的酒楼也十分繁华，门客络绎不绝。#character:Narration #style:Narration #place:5
我就是从被他的事迹所激励，刻苦练习厨艺，梦想有朝一日成为像他那样的大师，在我十九岁时，终于名动京城，但我认为我的厨艺还远远不够，于是我不远万里来到西域拜见这位大师。
然而，岁月无情，等我来到这栋酒楼时，大师早已逝去，酒楼也已经破败不堪。#character:Narration
我花了几天的时间重振酒楼，尽力恢复酒楼的部分功能，我相信即使大师已经不在人世，我只要用心感受，一定可以学习到大师厨艺的精髓。##character:Narration

-> ScenceOne

=== ScenceOne ===
//厨房 黄昏 内
#background:Lobby
呼……真辛苦，这样的话明天可以勉强开业了。#character:protagonist #place:4 #sound:BGM2 #track:2
这时门外传来一阵急促的敲门声，我连忙前往大厅。#character:Narration #style:Default #sound:KnockingDoor #track:1
//大厅 黄昏 内
来到大厅，主角看到一个中年人站在门口，他的脸看起来饱经风霜，一双灵活的眼睛滴溜溜的转动，打量着主角，看到主角走进，他摘下头上的破毡帽，向主角行礼。#character:Laofu  #place:2 #sound:none #track:1
自我介绍一下，我叫老福，诚实的老福，是这个镇子上的商人，听说你要在这里开店，那么你一定需要一个靠谱的供货商。#character:Laofu
既然你是本地人，那能不能和我说一下小镇？#character:protagonist 
当然可以。#character:Laofu
你想了解什么方面的内容？ #character:Laofu

-> Town

 
= Town

+[这个镇子的起源可以说给我听听吗]
这座城市的建立依附于一片绿洲,因此被称为“白玉小镇”最开始只是旅行商队的休息站,但渐渐的开起了各种商铺,小镇也渐渐形成最初的规模。#character:Laofu
->Town

+[你对这里的人了解多少]
因为是商业城市,这里什么人都有,西域人,中原人,波斯人,突厥人,也没有什么固定的信仰,小镇上有一座西域之神的神庙,大家会在冬日的最后一夜会在那里齐聚一堂,举行盛大的宴会来庆祝新一年的开始,那可是相当热闹呢!#character:Laofu
->Town


+[你们在这里做生意，要给哪位国王交税？]
从领地来说,这里属于哈密部落的版图,最初由哈密首领的税务官管理此地,在十几年前,哈密首领将这里作为封地封给了一位贵族,目前这个家族已经传到第二世女贵族。#character:Laofu
虽然贵族在此地有很高的话语权,但很少出面,一般还是要税务官去处理各种事务,哦对了,还有一位负责治安的捕快,虽然是本地人,但穿的可是大唐的官服,还是不得怠慢的。#character:Laofu
->Town

*{TURNS_SINCE(-> Town) != 0}原来如此,这小小镇子原来还有这么多故事。#character:protagonist
-> otherQuestion

= otherQuestion
+最近镇上有发生什么稀奇事吗?#character:protagonist
稀奇的事每天都有,镇子里买醋的掌柜夫人生孩子,孩子长得却不像丈夫。#character:Laofu
呃......除了这种呢?#character:protagonist
最近天气渐渐炎热起来,大家都想喝一杯清爽的酒水,所以酒类的价格马上要变高了。#character:Laofu
(自言自语)或许我可以在菜单上多添一些饮品。#character:protagonist
-> otherQuestion

+[关于你的脸......]
你好像带着一个很精致的......面具?#character:protagonist
老福的眼神中毫不掩饰的闪烁过狡诈的光芒,他轻轻张开嘴,似乎有意显露出细小的獠牙,搅动起鲜红的舌头#character:Narration
没有想到你居然能识破我的幻术,当然阁下不用担心,这个世界远远不只有你们人类行走在这片神圣的沙漠商道之上,
你若留心,能发现很多藏在人类中的我辈同族,还请阁下保守秘密。#character:Laofu
-> otherQuestion

+[我们来谈谈货物的事吧!]
我初来乍到,对这里的一切都不太熟悉,确实需要一个靠的住的供货商,那么你的报价是多少?#character:protagonist
我要二成的手续费。#character:Laofu
这有些太多了,最多一成半。#character:protagonist
加每天两餐饭。#character:Laofu
那要我决定饭菜的内容。#character:protagonist
-> aboutGoods

= aboutGoods
{成交|还有别的问题吗}#character:Laofu
*我想看一看货物#character:protagonist
当然没有问题。#character:Laofu
{|}#event:LoadFood
-> aboutGoods

*[同意供货合作]
那好吧，我没有问题了。#character:protagonist
明天早上我会把货物送来。#character:Laofu
老福说完,将桌子下的一个木箱子拖给你#character:Narration
箱子里整整齐齐的放着一些品质很高的酒和野果。#character:Narration
这是我的见面礼,希望我们合作愉快。#character:Laofu
那好,我去给你准备晚餐。#character:protagonist
哦,老板,您真的是太客气了。#character:Laofu
{|}#event:LoadBBQ
你将烤好的肉串端给老福，从烤肉中散发的香气已经将他的魂魄牢牢勾住，他激动的接过烤肉，在进食的过程中，你看到了一丝丝他本来面目的影子。#character:Narration
这才是人类该吃的东西，小镇上原来的厨师做的菜难吃极了，要比老福的妈妈做的菜还要难吃。#character:Laofu
老福看了看你，随后说。#character:Narration
因为老福的妈妈是一只普通的狐狸，所以它根本不会做饭。#character:Laofu
老福只吃了一串烤肉，他将剩下的烤肉小心翼翼的用纸包起来，擦去嘴角流出的口水，你猜到他大概是想以此卖个好价钱。#character:Laofu
你收下老福的见面礼，那些的确都是非常高品质的食材。#character:Narration
水果可以用来做点心或冷吃，酒水则立刻就发挥了用处，你将几瓶放在柜台预备，剩下的都储存进了地窖中。#character:Narration
{|}#event:LoadDay1

-> END



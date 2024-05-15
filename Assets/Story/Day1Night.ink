->Start
== Start ===
//晚上
第一天 傍晚 #character:Narration #place:5 #style:blackscreen
晚上你关闭了酒楼的大门,点起一盏灯在柜台上算账,晚风带来丝丝凉意,激起了你的疲倦#character:Narration #place:5 #style:Default #sound:BGM3 #track:2
不知过了多久,你趴在柜上沉沉睡去,恍惚间,听到有人在敲着柜台。#character:Narration
醒醒,老板,我要吃饭!#character:laoshu #place:2
你四下张望,却没有看到人影,正当你疑惑之际,你看到白天吓到女捕快的大老鼠正穿着人的衣服,站在柜台上对你说话。#character:Narration
一只大老鼠,穿着人类的衣服,站在你的眼前,它的眼睛很像人。#character:Narration
-(mouse)
+你是谁?#character:protagonist #place:4
    我可不是普通的老鼠,我是住在这里的精灵。#character:laoshu #place:2
    那不还是老鼠。#character:protagonist
    我不仅是个老鼠,还是你的顾客。#character:laoshu
    所以你现在要点菜了对吧?#character:laoshu
    你好像一点都不惊讶。#character:laoshu
    如果你在一天内连续遇到卖货的狐狸和凶杀案,晚上见到一只会说话的老鼠有什么稀奇的。#character:protagonist
    我还以为你会想那个女捕快一样被吓得跳起。#character:laoshu
    ->mouse
    
+你要点什么#character:protagonist #place:4
    我要世界上最美味的食物,不要企图糊弄我,我可是吃过大师做的菜哦!#character:laoshu
    嗯......难道是燕窝鸡丝汤?海参炖熊掌?还是莲花蒸鸭心?#character:protagonist
    那都是你们人类喜欢吃的东西,软软的,对老鼠来说不好吃。#character:laoshu
    是哦,人的牙齿随着年龄越来越少,但老鼠的牙齿随着年龄会越来越长,那什么样的东西才是你族的珍馐呢?#character:protagonist
    老鼠想了想,动作神态极度像人。#character:Narration
    当然是又硬又香的坚果,和甜丝丝的蜜饯了。#character:laoshu
    坚果,蜜饯,又硬又甜,唔,那应该是切糕了。#character:protagonist
-
-(master)
*[关于大师]
大师在这个酒楼营业的时候,我就出生在这的老鼠洞里在长时间吃大师做的菜后,我生成了一些灵性,因此厌恶了与同族垃圾堆里翻找食物的生活,在酒楼的地底下建立了一个花园居住。#character:laoshu
什么样的花园?#character:protagonist
大师曾经培育了很多特殊的珍贵香料,在他死后,我将一些香料种子带回我的洞中栽种,珍惜的香料才没有灭绝。#character:laoshu
看来你还真不是个简单的老鼠。#character:protagonist
那是当然,我今天来就是为了考验你的水平,看来你有大师的几分神韵，不过别得意,这只是刚刚开始,当然了,如果你能通过考验,奖励自然非常丰厚#character:laoshu
我会将经过我改良的香料种子赏赐给你,那可是你们厨师梦寐以求的至宝。#character:laoshu
-> master
*[做菜]
    {|}#event:LoadFood
-> Aftercook

=== Aftercook ===
老鼠在吃了一口你做的菜后,满意的站了起来,胡须激动地抖动。#character:Narration
真是令人怀念的味道......值得赞赏的技艺,但与大师比起来还是有很大的差距，不过说到做到,既然你已经满足我的要求,我会把答应好的香料送给你。#character:laoshu
{|}#event:LoadEND
-> END



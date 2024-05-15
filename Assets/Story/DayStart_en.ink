-> Start

=== Start ===

Legend has it that in the Western Regions, there was a true master of culinary arts. No one knew where he came from. He came to this town, stirred life's myriad flavors into his pot, and was revered by all. The inn he opened flourished, with guests coming and going continuously. #character:Narration #style:Narration #place:5
I was inspired by his deeds, diligently practiced my cooking skills, and dreamed of becoming a master like him. At the age of nineteen, I finally made a name for myself in the capital city. However, I felt my culinary skills were still far from sufficient, so I traveled thousands of miles to the Western Regions to meet this master.
However, time is merciless. By the time I arrived at the inn, the master had already passed away, and the inn had fallen into disrepair. #character:Narration
I spent several days revitalizing the inn, trying to restore some of its functions. I believe that even though the master is no longer in this world, if I feel with my heart, I can definitely learn the essence of the master's culinary arts. #character:Narration

-> ScenceOne

=== ScenceOne ===
// Kitchen Dusk Interior
#background:Lobby

Phew... It's been tough, but we can barely open for business tomorrow. #character:protagonist #place:4 #sound:BGM2 #track:2
At this moment, a rapid knocking sound came from the door, and I hurriedly went to the lobby. #character:Narration #style:Default #sound:KnockingDoor #track:1
// Lobby Dusk Interior
Upon arriving in the lobby, the protagonist sees a middle-aged man standing at the door. His face looks weathered, and his lively eyes are darting around, sizing up the protagonist. Seeing the protagonist walk in, he takes off his worn felt hat and bows. #character:Laofu #place:2 #sound:none #track:1
Let me introduce myself. My name is Laofu, honest Laofu, a merchant from this town. I heard you're opening a shop here, so you'll definitely need a reliable supplier. #character:Laofu
Since you're a local, could you tell me a bit about the town? #character:protagonist
Of course, I can. #character:Laofu
What would you like to know? #character:Laofu

-> Town

 
= Town

+[Can you tell me about the origin of this town?]
This city was built around an oasis, hence it was named "White Jade Town." It started as a rest stop for traveling caravans, but gradually various shops opened up, and the town began to take its initial shape. #character:Laofu
->Town

+[How much do you know about the people here?]
Since it's a commercial city, you'll find all sorts of people here: people from the Western Regions, the Central Plains, Persians, Turks, and there's no fixed religion. There's a temple to the god of the Western Regions in town, and on the last night of winter, everyone gathers there for a grand banquet to celebrate the start of the new year. It's quite lively! #character:Laofu
->Town


+[About doing business here, to which king do we have to pay taxes?]
Territorially, this place belongs to the Hami tribe's domain. Initially, it was managed by the tax officer of the Hami chieftain. About a decade ago, the Hami chieftain granted this place as a fief to a noble, and now the land has passed to the second generation of female nobles. #character:Laofu
Although the nobility has a lot of say here, they rarely show up, and it's generally up to the tax officer to handle various affairs. Oh, and there's also a constable responsible for maintaining public order. Although he's a local, he wears the official uniform of the Tang Dynasty, so you shouldn't neglect her. #character:Laofu
->Town

*{TURNS_SINCE(-> Town) != 0}So it turns out, this little town has quite a story. #character:protagonist
-> otherQuestion

= otherQuestion
+Has anything unusual happened in town recently? #character:protagonist
Unusual things happen every day. For example, the shopkeeper's wife who sells vinegar gave birth to a child who doesn't look like her husband at all. #character:Laofu
Uh... Anything else besides that? #character:protagonist
Lately, the weather has been getting hotter, and everyone wants to drink something refreshing, so the prices of alcoholic beverages are about to go up. #character:Laofu
(Muttering) Maybe I can add some more drinks to the menu. #character:protagonist
-> otherQuestion

+[About your face...]
You seem to be wearing a very intricate... mask? #character:protagonist
Laofu's eyes unashamedly flash with cunning, and he slightly opens his mouth, as if to intentionally reveal his sharp little fangs and stir his crimson tongue. #character:Narration
I didn't expect you to see through my illusion. Of course, you needn't worry. This world is not only inhabited by humans wandering these sacred desert trade routes. If you pay attention, you can find many of my kin hidden among humans. Please keep this a secret. #character:Laofu
-> otherQuestion

+[Let's talk about the goods!]
I'm new here and not familiar with everything, so I do need a reliable supplier. What's your price? #character:protagonist
I take a twenty percent commission. #character:Laofu
That's a bit too much, no more than fifteen percent. #character:protagonist
Plus two meals a day. #character:Laofu
Then I decide what the meals are. #character:protagonist
-> aboutGoods

= aboutGoods
Deal  #character:Laofu
*I want to take a look at the goods. #character:protagonist
No problem at all. #character:Laofu
{|} #event:LoadFood
-
Any other questions? #character:Laofu
*[Agree to the supply partnership]
    Alright, I have no more questions. #character:protagonist
    I'll bring the goods over tomorrow morning. #character:Laofu
    After saying this, Laofu drags a wooden box from under the table to you. #character:Narration
    The box neatly contains some very high-quality liquor and wild fruits. #character:Narration
    This is my greeting gift. I hope our cooperation will be pleasant. #character:Laofu
    Alright, I'll go prepare your dinner. #character:protagonist
    Oh, boss, you're really too kind. #character:Laofu
    {|} #event:LoadBBQ
    You serve the grilled skewers to Laofu, and the aroma of the grilled meat firmly captures his soul. He excitedly takes the grilled meat, and during the eating process, you see a hint of his true form. #character:protagonist
This is what humans should eat. The original chefs in town cooked terribly, even worse than Laofu's mother's cooking. #character:Laofu
Laofu looked at you, then said. #character:Narration
Because Laofu's mother is an ordinary fox, so she can't cook at all. #character:Laofu
Laofu only ate one skewer of grilled meat. He carefully wrapped the rest of the grilled meat in paper, wiping the drool from the corner of his mouth, you guessed he probably wants to sell it at a good price. #character:Laofu
You accept Laofu's greeting gift, and indeed, they are all very high-quality ingredients. #character:protagonist
The fruits can be used for desserts or eaten cold, and the liquor was immediately useful. You place a few bottles on the counter for preparation, and the rest are stored in the cellar. #character:protagonist
{|} #event:LoadDay1

-> END

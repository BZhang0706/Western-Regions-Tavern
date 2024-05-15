->Start

=== Start ===
//Evening
Day 1 Evening #character:Narration #place:5 #style:blackscreen
You close the doors of the inn for the night, light a lamp on the counter to do the accounts, and the evening breeze brings a chill that awakens your fatigue. #character:Narration #place:5 #style:Default #sound:BGM3 #track:2
After an unknown amount of time, you fall asleep on the counter, and in a daze, you hear someone knocking on the counter. #character:Narration
Wake up, boss, I want to eat! #character:laoshu #place:2
You look around but see no one. Just as you're puzzled, you see the large rat that scared the female constable during the day, now wearing human clothes, standing on the counter talking to you. #character:Narration
A large rat, wearing human clothes, stands before you, its eyes very human-like. #character:Narration
-(mouse)
+Who are you? #character:protagonist #place:4
    I'm not just any rat; I'm a sprite living here. #character:laoshu #place:2
    So you're still a rat. #character:protagonist
    I'm not just a rat; I'm also your customer. #character:laoshu
    So you want to order now, right? #character:laoshu
    You don't seem surprised at all. #character:laoshu
    If you encounter a merchant fox and a murder case in one day, seeing a talking rat at night is nothing unusual. #character:protagonist
    I thought you'd jump like that female constable. #character:laoshu
    ->mouse
    
+What would you like to order? #character:protagonist #place:4
    I want the most delicious food in the world, don't try to fool me, I've eaten dishes made by the master! #character:laoshu
    Hmm... could it be bird's nest soup with chicken strips? Sea cucumber stewed with bear's paw? Or lotus-steamed duck heart? #character:protagonist
    Those are all things you humans like to eat, soft, not tasty for rats. #character:laoshu
    Oh, human teeth diminish with age, but a rat's teeth grow longer as they age. So, what delicacy is prized by your kind? #character:protagonist
    The rat ponders, acting very human-like. #character:Narration
    Of course, it's hard and fragrant nuts, and sweet candied fruits. #character:laoshu
    Nuts, candied fruits, hard and sweet, hmm, that must be qiegao. #character:protagonist
-
-(master)
*[About the master]
When the master was running this inn, I was born in a mouse hole here. After eating the master's cooking for a long time, I developed some spirituality and grew tired of scavenging for food in trash heaps with my kind. I built a garden to live in underneath the inn. #character:laoshu
What kind of garden? #character:protagonist
The master once cultivated many special and precious spices. After he died, I took some of the spice seeds back to my hole to plant, ensuring the precious spices didn't go extinct. #character:laoshu
It seems you're not just any ordinary rat. #character:protagonist
Of course not. I came today to test your skills. You have a bit of the master's flair, but don't get cocky, this is just the beginning. Of course, if you pass the test, the reward will be very generous. #character:laoshu
I will reward you with the spice seeds I've improved, which are treasures every chef dreams of. #character:laoshu
-> master
*[Cooking]
    {|}#event:LoadFood
-> Aftercook

=== Aftercook ===
After taking a bite of your dish, the rat stands up satisfied, its whiskers trembling with excitement. #character:Narration
This taste is nostalgic... commendable skill, but there's still a big gap compared to the master. However, I keep my promises, and since you've met my request, I'll give you the promised spices. #character:laoshu
{|}#event:LoadEND
-> END
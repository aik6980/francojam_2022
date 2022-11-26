INCLUDE PlayerState.ink

/*
VAR rusty_likes_dogs=3
VAR rusty_likes_cats=1
VAR rusty_likes_kids=1
VAR rusty_likes_walks=7
VAR rusty_smart=9
VAR rusty_active=8
VAR rusty_playful=4
*/
VAR affinity=4

-> round_1

=== round_1 ===
Good morning. #Name_Rusty
Forgive my apprehension. You're quite large. #Name_Rusty
Tall, that is. Apologies, don't be misconstrued. #Name_Rusty
 * [You sound fancy]You have a lovely manner of speaking! #Name_Me

-My thanks. I've had many years to practice. #Name_Rusty
It's not easy keeping up with the younglings' speech patterns... thus I tend not to. #Name_Rusty
If I'm frank, I can't keep up with them at all. #Name_Rusty
 * [You'd love my kids]I'm sure you'll be able to keep up with my kids! #Name_Me
 I'd much rather not. #Name_Rusty
 ~ affinity = affinity - 2
 -> round_2
 * [I understand]I understand; I'm an old soul myself. #Name_Me
 I'm glad we're on the same proverbial page. #Name_Rusty
 -> round_2
 * {likes_kids < 3}[I've got no kids]No rugrats, no regrets - that's my motto. #Name_Me
 Not the words I would have used... but I like it. :-) #Name_Rusty
 ~ affinity = affinity + 2
 -> round_2

-> round_2

=== round_2 ===
 Ah, you've returned. #Name_Rusty
 Come to converse with the resident old timer again? #Name_Rusty
 * [Quite happily]You say that like it's a negative thing. #Name_Me
 
 -You're too kind. #Name_Rusty
 It's most enjoyable to see a familiar face - but... #Name_Rusty
 It's even better to see a familiar place. I've so many memories made across so many locations. #Name_Rusty
 * {likes_walks > 7}{active > 7}[One walk to see them all?]Imagine seeing them all in one walk! #Name_Me
 Oho, what a treat that would be! :-D #Name_Rusty
 ~ affinity = affinity + 2
 -> round_3
 * [I bet you've seen a lot]You sound very well travelled. #Name_Me
 When you reach my age, you've seen everything. #Name_Rusty
 -> round_3
 * [Home is where the heart is]There's nothing quite like home though, right? #Name_Me
 ...I suppose. #Name_Rusty
 ~ affinity = affinity - 2
-> round_3

-> round_3
 
 === round_3 ===
 Goodness me, it's like looking into a mirror! #Name_Rusty
 Time's arrow marches onwards, does it not? #Name_Rusty
 {affinity > 7: Welcome back, old friend.} #Name_Rusty
 {affinity <= 7: Welcome back.} #Name_Rusty
 * How's life? #Name_Me
 
 -It continues. #Name_Rusty
 Though forgive me, for I must ask: #Name_Rusty 
 What keeps you coming back here? #Name_Rusty
 * [I love dogs]Honestly? I just love dogs! #Name_Me
 How sweet. :-)
 -> END
 * {smart > 8}[We all need a friend]We all need the feeling of companionship. To deny that is to deny our nature. #Name_Me
 Life without a best friend is one I dare not imagine. #Name_Rusty
  ~ affinity = affinity + 2
 -> END
 * [I don't know]I don't know. #Name_Me
 ...I see. #Name_Rusty
 ~ affinity = affinity - 2
 -> END
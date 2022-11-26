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
Good morning.
Forgive my apprehension. You're quite large.
Tall, that is. Apologies, don't be misconstrued.
 * [You sound fancy]You have a lovely manner of speaking!

-My thanks. I've had many years to practice.
It's not easy keeping up with the younglings' speech patterns... thus I tend not to.
If I'm frank, I can't keep up with them at all.
 * [You'd love my kids]I'm sure you'll be able to keep up with my kids!
 I'd much rather not.
 ~ affinity = affinity - 2
 -> round_2
 * [I understand]I understand; I'm an old soul myself.
 I'm glad we're on the same proverbial page. 
 -> round_2
 * {likes_kids < 3}[I've got no kids]No rugrats, no regrets - that's my motto.
 Not the words I would have used... but I like it. :-)
 ~ affinity = affinity + 2
 -> round_2

-> round_2

=== round_2 ===
 Ah, you've returned.
 Come to converse with the resident old timer again?
 * You say that like it's a negative thing.
 
 -You're too kind.
 It's most enjoyable to see a familiar face - but...
 It's even better to see a familiar place. I've so many memories made across so many locations.
 * {likes_walks > 7}{active > 7}[One walk to see them all?]Imagine seeing them all in one walk!
 Oho, what a treat that would be! :-D
 ~ affinity = affinity + 3
 -> round_3
 * [I bet you've seen a lot]You sound very well travelled.
 When you reach my age, you've seen everything.
 -> round_3
 * [Home is where the heart is]There's nothing quite like home though, right?
 ...I suppose.
 ~ affinity = affinity - 3
-> round_3

-> round_3
 
 === round_3 ===
 Goodness me, it's like looking into a mirror!
 {affinity > 7}Welcome back, old friend.
 {affinity <= 7}Welcome back.
 * How's life?
 
 -It continues.
 Though forgive me, for I must ask: 
 What keeps you coming back here?
 * [I love dogs]Honestly? I just love dogs!
 How sweet. :-)
 -> END
 * {smart > 8}[We all need a friend]We all need the feeling of companionship. To deny that is to deny our nature.
 Life without a best friend is one I dare not imagine.
  ~ affinity = affinity + 4
 -> END
 * [I don't know]I don't know.
 ...I see.
 ~ affinity = affinity - 4
 -> END
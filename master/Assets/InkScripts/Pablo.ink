INCLUDE PlayerState.ink

/*
VAR pablo_likes_dogs=6
VAR pablo_likes_cats=2
VAR pablo_likes_kids=10
VAR pablo_likes_walks=6
VAR pablo_smart=5
VAR pablo_active=6
VAR pablo_playful=6
*/
VAR affinity=4

-> round_1

=== round_1 ===
omg hi!!!
im pablo n im HYPED TO MEET YOU :DDD
its not every day u get to make a new friend <3333
*[You seem happy]You seem happy!

- u would be too if u sniffed a few things around here!!
u wouldnt believe what kinds of things happen!!
like... uh,,,
*{likes_kids > 5}[Visitors?]You get people visiting you?
YEAH n its the BEST!!! ^_^ i <3 humans!! specially the little ones!
~ affinity = affinity + 2
-> round_2
*[Food?]You get to eat food?
FOOD???? WHERE???????
-> round_2
*[Dog... things?]Like... dog things? That dogs do?
yh i guess
~affinity = affinity - 2
-> round_2

=== round_2 ===
ur back!! <3
how r u doin friend???
i cant wait to talk about ur day!!
*[It's been good]It's been good! How about yours?

-HELL YEAH!!! :DDDD
mines been good too!
i did almost see a cat but now ur here its SO much better!!
*{likes_cats >= 5}[Cats are the best]But cats are the best!
??? y r u here then??
~ affinity = affinity - 2
->round_3
*{likes_cats < 5}[Cats are the worst]I'd be mad if I saw a cat!
RIGHT?!??!? humans >>>> cats imo
~ affinity = affinity + 2
->round_3
*[Cats are fine]At least it was only almost!
yh it was actually just a mirror :/ but i know now!
->round_3

=== round_3 ===
:OOO OMG ITS U
lets talk lets talk!!
im always happy to see u <3
*[You too]The feeling's mutual!

-<3333
ive been playing fetch with the wall!
now ur here you can play!!
*[Soon]I've got more dogs to visit, but soon we'll play!
ok! they deserve time with u too <33
->END
*{playful > 7}[Sure]Let's do it!
!!!! <3<3<3<3
~ affinity = affinity + 2
->END
*[I'm tired]Maybe another day?
oh... ok
~ affinity = affinity - 2
->END
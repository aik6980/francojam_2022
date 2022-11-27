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
omg hi!!! #Name_Pablo
im pablo n im HYPED TO MEET YOU :DDD #Name_Pablo
its not every day u get to make a new friend <3333 #Name_Pablo
*[You seem happy]You seem happy! #Name_Me

- u would be too if u sniffed a few things around here!! #Name_Pablo
u wouldnt believe what kinds of things happen!! #Name_Pablo
like... uh,,, #Name_Pablo
*{likes_kids > 5}[Visitors?]You get people visiting you? #Name_Me
YEAH n its the BEST!!! ^_^ i <3 humans!! specially the little ones! #Name_Pablo
~ affinity = affinity + 2
*[Food?]You get to eat food? #Name_Me
FOOD???? WHERE??????? #Name_Pablo
*[Dog... things?]Like... dog things? That dogs do? #Name_Me
yh i guess #Name_Pablo
~affinity = affinity - 2
- -> DONE

=== round_2 ===
ur back!! <3 #Name_Pablo
how r u doin friend??? #Name_Pablo
i cant wait to talk about ur day!! #Name_Pablo
*[It's been good]It's been good! How about yours? #Name_Me

-HELL YEAH!!! :DDDD #Name_Pablo
mines been good too! #Name_Pablo
i did almost see a cat but now ur here its SO much better!! #Name_Pablo
*{likes_cats >= 5}[Cats are the best]But cats are the best! #Name_Me
??? y r u here then?? #Name_Pablo
~ affinity = affinity - 2
*{likes_cats < 5}[Cats are the worst]I'd be mad if I saw a cat! #Name_Me
RIGHT?!??!? humans >>>> cats imo #Name_Pablo
~ affinity = affinity + 2
*[Cats are fine]At least it was only almost! #Name_Me
yh it was actually just a mirror :/ but i know now! #Name_Pablo
- -> DONE

=== round_3 ===
:OOO OMG ITS U #Name_Pablo
lets talk lets talk!! #Name_Pablo
im always happy to see u <3 #Name_Pablo
*[You too]The feeling's mutual! #Name_Me

-<3333 #Name_Pablo
ive been playing fetch with the wall! #Name_Pablo
now ur here you can play!! #Name_Pablo
*[Soon]I've got more dogs to visit, but soon we'll play! #Name_Me
ok! they deserve time with u too <33 #Name_Pablo
->END
*{playful > 7}[Sure]Let's do it! #Name_Me
!!!! <3<3<3<3 #Name_Pablo
~ affinity = affinity + 2
->END
*[I'm tired]Maybe another day? #Name_Me
oh... ok #Name_Pablo
~ affinity = affinity - 2
->END
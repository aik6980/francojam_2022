INCLUDE PlayerState.ink

/*
VAR otis_likes_dogs=8
VAR otis_likes_cats=4
VAR otis_likes_kids=5
VAR otis_likes_walks=3
VAR otis_smart=10
VAR otis_active=2
VAR otis_playful=8
*/
VAR affinity=4

-> round_1

=== round_1 ===
- Heya! How are you? My name's Otis! It's great to meet you!
I like your profile pic, you look super nice.
It's a real shame these phones don't have smell too. You can learn a lot about someone that way y'know?
 * :)

- Hey, so would you like to chat for a bit?
It's so good to get to speak to someone new, I get a little stir crazy sometimes!
There's only so many times you can read White Fang before you start looking for someone to talk to... or a Yukon forest to run in.
 * [Prefer Lassie]I'm more of a Lassie: Come home fan
 Oh, uh... yeah. I-I like that one too...
 ~ affinity = affinity - 2
 -> round_2
 * [Not yet]I've been meaning to read that one!
 You really should! It's so good it makes me want to bark! -> round_2
 * {smart > 5}[Love it!]I love that story, but Beauty Smith is a monster. \>\:\|
 But Scott is such a good person, you need a terrible villian to show him against.
 ~ affinity = affinity + 2
 -> round_2


=== round_2 ===
= part_1
- As you enter the Holbrook Shelter you see a little black and brown Dachshund playing with another dog.
When you approach he notices you and gives an { affinity > 5 : excited | nervous } wag of his tail.
Oh hey! It's so good to see you! I { affinity > 5 : really } enjoyed our chat together. I was hoping I'd get to meet you in person.
 * Ask about friend
 - That's Betty, she and I started a book club together... Only, we're the only ones to join.
 Oh, but it's still great to talk about new books!
 Say, do you have any other dogs at home?
 * { has_dog } Yes! A house isn't a home without a dog.
 ~ affinity = affinity + 1
  Oh how wonderful! I should have known. I can even smell them on you. Can you tell me about them?
 -> part_2
 * No, but I wouldn't mind more.
  That's a bit sad, but perhaps we could find another forever friend together?
 -> part_2
 * No, one doggo is enough of a handful for me!
  Oh... That's a bit sad.
 ~ affinity = affinity - 2
 -> part_2

= part_2
-> END
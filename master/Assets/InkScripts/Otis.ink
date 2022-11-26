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
- Heya! How are you? My name's Otis! It's great to meet you! #Name_Otis
I like your profile pic, you look super nice. #Name_Me
It's a real shame these phones don't have smell too. You can learn a lot about someone that way y'know? #Name_Otis
 * :) #Name_Me #Emote_Happy

- Hey, so would you like to chat for a bit? #Name_Otis
It's so good to get to speak to someone new, I get a little stir crazy sometimes! #Name_Otis
There's only so many times you can read White Fang before you start looking for someone to talk to... or a Yukon forest to run in. #Name_Otis
 * [Prefer Lassie]I'm more of a Lassie: Come home fan #Name_Me
 Oh, uh... yeah. I-I like that one too... #Name_Otis
 ~ affinity = affinity - 2
 -> round_2
 * [Not yet]I've been meaning to read that one! #Name_Me
 You really should! It's so good it makes me want to bark! #Name_Otis 
 -> round_2 
 * {smart > 5}[Love it!]I love that story, but Beauty Smith is a monster. \>\:\| #Name_Me
 But Scott is such a good person, you need a terrible villian to show him against. #Name_Otis
 ~ affinity = affinity + 2
 -> round_2


=== round_2 ===
= part_1
- As you enter the Holbrook Shelter you see a little black and brown Dachshund playing with another dog.
When you approach he notices you and gives an { affinity > 5 : excited | nervous } wag of his tail.

Oh hey! It's so good to see you! I { affinity > 5 : really } enjoyed our chat together. I was hoping I'd get to meet you in person. #Name_Otis
 * Ask about friend #Name_Me
 - That's Betty, she and I started a book club together... Only, we're the only ones to join. #Name_Otis
 Oh, but it's still great to talk about new books! #Name_Me
 Say, do you have any other dogs at home? #Name_Otis
 * { has_dog } Yes! A house isn't a home without a dog. #Name_Me
 ~ affinity = affinity + 1
  Oh how wonderful! I should have known. I can even smell them on you. Can you tell me about them? #Name_Otis
 -> part_2
 * No, but I wouldn't mind more. #Name_Me
  That's a bit sad, but perhaps we could find another forever friend together? #Name_Otis
 -> part_2
 * No, one doggo is enough of a handful for me! #Name_Me
  Oh... That's a bit sad. #Name_Otis
 ~ affinity = affinity - 2
 -> part_2

= part_2
-> END
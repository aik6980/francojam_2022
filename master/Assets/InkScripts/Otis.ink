INCLUDE PlayerState.ink
INCLUDE DogState.ink

-> round_2

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


=== round_1 ===
#location: In App
#topic: smart
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
 * [Not yet]I've been meaning to read that one! #Name_Me
 You really should! It's so good it makes me want to bark! #Name_Otis
 * {smart > 5}[Love it!]I love that story, but Beauty Smith is a monster. #Name_Me #Emote_Angry
 But Scott is such a good person, you need a terrible villian to show him against. #Name_Otis
 ~ affinity = affinity + 2
- -> DONE


=== round_2 ===
#location: Holbrook Shelter
-> part_1

= part_1
#topic: dogs
- As you enter the Holbrook Shelter you see a little black and brown Dachshund playing with another dog.
When you approach he notices you and gives an { affinity > 5 : excited | nervous } wag of his tail.

Oh hey! It's so good to see you! I { affinity > 5 : really } enjoyed our chat together. I was hoping I'd get to meet you in person. #Name_Otis
 * Ask about friend #Name_Me
 - That's { betty_available : Betty| Hatty}, she and I started a book club together... Only, we're the only ones to join. #Name_Otis
 Oh, but it's still great to talk about new books! #Name_Me
 Say, do you have any other dogs at home? #Name_Otis
 * { has_dog } Yes! A house isn't a home without a dog. #Name_Me
 ~ affinity = affinity + 1
  Oh how wonderful! I should have known. I can even smell them on you. I'd love to meet them sometime. #Name_Otis
 * No, but I wouldn't mind more. #Name_Me
  That's a bit sad, but perhaps we could find another forever friend together? #Name_Otis
 * No, one doggo is enough of a handful for me! #Name_Me
  Oh... That's a bit sad. #Name_Otis
 ~ affinity = affinity - 2
- -> part_2

= part_2
#topic: walks
- The two of you fall into an easy stroll around the exercise yard as you chat. As you walk and talk you notice Otis is struggling to keep up.
    * [Getting tired?]
        Well... I'm never going to say no to a little walk... you've just got long legs. #Name_Otis
        ~ affinity = affinity - 1
    * [Find a spot to sit] 
        It's nice to sit and chat. I've only got these little legs, sometimes I get a little worn out. #Name_Otis
- So, do you go for lots of longer walks?
    * { likes_walks > 6 && active > 4 } [Who doesn't!?] #Name_Me
        ~ affinity = affinity - 3
        I-I guess... #Name_Otis #Emote_Nervous
    * [Yeah.]Oh, yeah. I guess so, I hadn't really thought about it. #Name_Me
        ~ likes_walks = likes_walks + 1
        ~affinity = affinity - 1
        It's ok. I like them too. #Name_Otis #Emote_Nervous
    * { active > 6 }[Nature AmIRite?] #Name_Me
        ~ active = active + 1
        ~ affinity = affinity - 1
        ... Yeah. All that... nature... and ticks.  #Name_Otis #Emote_Nervous
    * [Meh.] I don't mind them, it's nice to get out sometimes. #Name_Me
        Yeah, I like a good walk. Just not all the time. #Name_Otis #Emote_Happy
    * { active < 4 } I much prefer a cozy armchair. #Name_Me
        ~ likes_walks = likes_walks - 1
        ~ affinity = affinity + 2
        An armchair? By a fire? With a book? #Name_Otis
        Heavenly...  #Name_Otis #Emote_Happy
- -> DONE

=== round_3 ===
#location: Park
->part_1

= part_1
#topic: kids
- You see the black and brown coat of little Otis as you approach the little restaurant in the park.
Otis is looking uneasy amongst the bustle of park. Kids run around the little fellow making him twitch and flinch.
When he sees you his face lights up{affinity > 7 : and his whole manner changes, visibly relaxing.|.}
    * [Icecream?]Do you want to get a table in the shade and have an icecream? #Name_Me
    Uh, yeah? That should be fine. #Name_Otis #Emote_Nervous
    I like icecream.  #Name_Otis #Emote_Happy
    You settle Otis at a bench in the shade outside the restaurant, while you go inside to get icecream.
    When you come out Otis seems a bit skittish, but he tucks into the icecream you offer him.
    * [Go somewhere else?]Do you want to go somewhere quieter? #Name_Me
    Quieter? Oh, yes please. #Name_Otis #Emote_Happy
    It gets a bit noisy with the pups around. #Name_Otis
    The two of you go for a {active < 5 || likes_walks < 5:short stroll|walk} over to a nice bench in the shade of the trees.
-So, do... do you like children? #Name_Otis
    * {likes_kids > 7}[Love them!]I love them! I would love to have a big family. #Name_Me
        ~ affinity = affinity - 1
        That sounds really... noisy. #Name_Otis #Emote_Nervous
    * {likes_kids > 5 && likes_kids < 7}[Older ones are OK]The older ones are fine. You know, once they stop all the messy stuff. #Name_Me
            ~ affinity = affinity + 1
    * I like them fine. #Name_Me
    * {likes_kids < 3}[Nope!]Nope, I'm not really interested in rug rats. #Name_Me
    Oh, that's a bit of a shame. I don't mind them once they get a bit older. #Name_Otis
    It's the running and noisy stage that makes my ears twitch. #Name_Otis
- -> part_2

= part_2
#topic: active/playful
- Otis fidgets back and forth in the shade as the two of you sit, settling himself down with a slightly nervous sidelong glance at you.
    * [Play ball?]Hey, do you want to play fetch? #Name_Me
    ~ affinity = affinity - 1
    ~ active = active + 1
    Uhh, sure? We can do that for a bit, if you like. #Name_Otis #Emote_Nervous
    * [Play chase?]C'mon, lets see if you can catch me! #Name_Me
    ~ affinity = affinity - 2
    ~ active = active + 1
    Wait... what? #Name_Otis #Emote_Surprised
    Otis looks worried as you dash off. He scampers after you as quickly as his  little legs can carry him. #Name_Otis
    * [Tricks?]Can you do any tricks? #Name_Me
    ~ affinity = affinity + 1
    ~ smart = smart + 1
    Can I?! #Name_Otis
    Otis throws himself into a staggering walk that could win praise on the hammyest stage before rolling over in a perfect mockery of death, doggy tongue lolling and eyes rolling.
    It's such a funny site you can't help but laugh.
    Together the two of you spend a happy time together, Otis demonstrating a surprisingly wide repertoire of increasingly clever tricks.
    * [Sit quietly]
    The two of you sit together in companionable silence, the only noises the wind in the trees and the occasional shuffle of paws.
    ~ affinity = affinity - 1
    ~ active = active - 1
- -> part_3
= part_3
#topic: cats
- After a lovely afternoon in the park it's finally time to take Otis back to the shelter.{affinity > 7: It's tough to take the little fuzzball back, you kind of want the afternoon to last forever.}
    On the walk back you feel Otis stiffen on the lead, his attention fixed on a now empty stretch of pavement in a side road.
    * What is it boy? #Name_Me
- Otis shakes himself before starting to walk on.
    How do you feel about cats? #Name_Otis
    * {likes_cats > 7}[Great]Cats are great, they're cute little purr-balls. #Name_Me
    * [Good]Cats are good, I mean I like all sorts of animals. #Name_Me
    * [Not a fan]I'm not really a fan. They're so aloof, it's hard to know what they're thinking. #Name_Me
    Yeah, me too. They seem to think their better than people, and I love people. #Name_Otis
    * {likes_cats < 3}[Yuck]Cats are the worst. Did you know they can have a parasite in their pee that makes you actually like them? Bleh. #Name_Me
    Wait, what? Really?! Eww! #Name_Otis
    Otis shudders in revulsion.
- The two of you finish your walk back to the shelter, chatting aimiably. When you arrive{affinity > 7: it's hard to| you} hand over his lead to the volunteer.
    You give him a parting {affinity > 7:hug|pat} and turn away. But before you get two paces you draw up short.
    * {affinity > 7}[Adopt him]Otis needs his forever home, and you know you can give him the love and stimulation that he really needs. You turn back and call out.
        Wait! I want to adopt him! #Name_Me
        Can we do the paperwork today? #Name_Me #Emote_Happy
    * [Head home]Otis is a great dog, but you're just not sure that the two of you are a perfect fit. With a heavy heart you return home.
        Maybe another dog will be the one for you. #Emote_Sad
- -> DONE
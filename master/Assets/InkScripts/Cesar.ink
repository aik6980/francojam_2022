INCLUDE PlayerState.ink

/*
VAR cesar_likes_dogs=7
VAR cesar_likes_cats=2
VAR cesar_likes_kids=5
VAR cesar_likes_walks=8
VAR cesar_smart=2
VAR cesar_active=3
VAR cesar_playful=6
*/
VAR affinity=4

-> round_1

=== round_1 ===
Hello? #Name_Cesar
My name is Cesar. It is nice to meet you. #Name_Cesar
Sorry for my bad English. I used to live in Cyprus. #Name_Cesar
 * [What bad English?]Don't worry, you're speaking it perfectly! #Name_Me

-That is very good to hear.  #Name_Cesar
You seem like a friendly person. #Name_Cesar
I like to be friendly, but trust is difficult. How do you make trust easy? #Name_Cesar
 * [That's a tough question]Oh, that's a tough one. At the very least, it certainly takes time! #Name_Me
 But how to reduce time? That we do not know. #Name_Cesar
 -> round_2
 * {playful > 5}[Good times build bonds]I find both dogs and humans enjoy a good play together! #Name_Me
 This makes sense to me. Maybe we try one day? :) #Name_Cesar
  ~ affinity = affinity + 2
 -> round_2
 * [Tough love]Owner knows best, in my opinion. Strict rules and tough love means less disobedience! #Name_Me
 I can tell you, this does not work with me. #Name_Cesar
 ~ affinity = affinity - 2
 -> round_2

-> round_2

=== round_2 ===
 Hello again! #Name_Cesar
 I have been playing with other dogs since our last talk. Much fun! #Name_Cesar
 Humans are much more interesting, however!
 * [You've come out of your shell]You look like you're enjoying yourself! You've come out of your shell quite a lot! #Name_Me
 
 -? #Name_Cesar
 I do not know what this means. #Name_Cesar
 I do not have a shell. #Name_Cesar
 * {smart > 7}[Actually, it's an idiom]It's an idiom! "A group of words established by usage as having a meaning not deducible from those of the individual words." #Name_Me
 I understand even less now. #Name_Cesar
 ~ affinity = affinity - 2
 -> round_3
 * [It doesn't matter]Don't worry. What matters is you're enjoying yourself! #Name_Me
 This is true! Unlike having a shell. As I say, I do not have one. #Name_Cesar
-> round_3
 * [It's a saying]It's something English-speaking people say that means you're more social, or less shy! #Name_Me
 Aha! Like a snail! I understand now! #Name_Cesar
 ~ affinity = affinity + 2
 -> round_3

-> round_3
 
 === round_3 ===
 Hello once more! #Name_Cesar
 My English is getting better every day. #Name_Cesar
 I'm even using contractions! You see there? #Name_Cesar
 * [I'm happy for you]I'm so happy for you! English isn't an easy language to learn, particularly for a dog! #Name_Me
 
 -You're correct! It's a long process. #Name_Cesar
 Now that it has improved, I wish to explore all of England, and learn even more! #Name_Cesar 
 Do you know of any routes to take? #Name_Cesar
 * {likes_walks > 7}[I am a living library of walks]I know so many walks, if you're up for them! #Name_Me
 Yes! It would bring me great joy!
 ~ affinity = affinity + 2
 -> END
 *[Let's start small]Maybe we should start off with small walks around here first? #Name_Me
 Were we not given legs to explore, and mouths to communicate? Let us not waste these! #Name_Cesar
  ~ affinity = affinity - 2
 -> END
 * [I have a few]I've got a few up my sleeve. #Name_Me
 Another of your sayings! I understand these now! #Name_Cesar
 -> END
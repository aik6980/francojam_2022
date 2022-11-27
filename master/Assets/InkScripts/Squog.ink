INCLUDE PlayerState.ink

/*
VAR squog_likes_dogs=10
VAR squog_likes_cats=1
VAR squog_likes_kids=7
VAR squog_likes_walks=3
VAR squog_smart=9
VAR squog_active=8
VAR squog_playful=2
*/
VAR affinity=4

-> round_1

=== round_1 ===
Woof! #Name_Squog
Yes! Woof! For I am a dog. #Name_Squog
My name is Squ...og. Squog. Bark bark woof. #Name_Squog
*[Pretty small for a dog]You might be the smallest dog I've ever seen! #Name_Me

-Iron deficiency. It'll do that to ya. #Name_Squog
Listen, do me a favour, okay? #Name_Squog
If you see any cats, you gotta warn me immediately, capiche? #Name_Squog
*{likes_cats < 5}[Will do]Uh, sure? #Name_Me
Thanks mate! I mean... Bork? #Name_Squog
~affinity = affinity + 2
*[Not a fan?]Not a fan of cats, huh? #Name_Me
You don't even know the half of it. Hopefully you never will! #Name_Squog
*[Aren't cats scared of dogs?]Haven't you got it the wrong way round? Cats usually chase rodents, not dogs... #Name_Me
Exactly! I mean- No... Just- Never mind!  #Name_Squog
~affinity = affinity - 2

- -> DONE

=== round_2 ===
These cats are driving me nuts! #Name_Squog
Ahh... nuts... <3 #Name_Squog
Oh! You! Uh, bark! Woof! Et cetera! #Name_Squog
*[Nuts?]What was that about nuts? #Name_Me

-Don't worry your pretty little head about it! #Name_Squog
But uh... while you're here... #Name_Squog
Do you know where to get some acorns? #Name_Squog
*[The ground]They're probably on the ground here somewhere! #Name_Me
Gee, thanks. That's super helpful. #Name_Squog
~affinity = affinity - 2
*[Trees]They come from certain kinds of trees, right? #Name_Me
So you don't know which ones? I'm kinda struggling here. #Name_Squog
*{smart >= 7}[Oak trees]They come from oak trees. I can't imagine they'll be very tasty for a dog, though. #Name_Me
You'd be surprised! Don't knock 'em till you try 'em, I say. Oh, woof, by the way. #Name_Squog
~affinity = affinity + 2

- -> DONE

=== round_3 ===
{affinity > 7: Aha! The helpful human!} #Name_Squog
{affinity <=7: Aha! It's... you!} #Name_Squog
Woof and bark and all that jazz. #Name_Squog
Did you have a good hibernation? #Name_Squog

*[Humans don't do that]Ah, we humans don't do that. We're always up and about, except at night when we sleep. #Name_Me

-Suit yourselves. Hibernation's way better though. ...bork. #Name_Squog
Gives you plenty of energy for the entire rest of the year! #Name_Squog
Although having said that... Maybe overly energetic humans for half the year isn't such a good idea. #Name_Squog
*[Let nature decide]We've evolved this way for a reason! Regardless of my opinion, it's now nature wants us to be. #Name_Me
But it's a fun thought experiment, no? #Name_Squog
->END
*[That means better playtime]That means plenty of energy for play! Wouldn't you like that? #Name_Me
NO! Wait, yes? What do dogs like? #Name_Squog
~affinity = affinity - 2
->END
*{playful < 4}[I prefer how I am]I don't need the extra energy. I'm happy as I am right now! #Name_Me
That's probably for the best. I just thought about you picking me up. No offense - I like to climb trees, not humans. Dogs can climb trees, right? #Name_Squog
~affinity = affinity + 2
->END
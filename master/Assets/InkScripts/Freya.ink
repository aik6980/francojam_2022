INCLUDE PlayerState.ink

/*
VAR freya_likes_dogs = 7
VAR freya_likes_cats = 2
VAR freya_likes_kids = 0
VAR freya_active = 6
VAR freya_playful = 7
VAR freya_smart = 6
VAR freya_likes_walks = 7
*/

VAR affinity=4

-> round_1

=== round_1 ===

Hi! I'm Freya! #Name_Freya
I'm happy to meet you, I hope we'll be able to spend time together! #Name_Freya
It gets a bit dull here, I hope you can take me out for a spin! #Name_Freya
Do you spend a lot of time outside? #Name_Freya

    *{likes_walks > 5}[I love walks]I do, there are a lot of paths you can walk around, would love to take you along one day! #Name_Me
        That sounds amazing! Would love to! #Name_Freya
        ~affinity = affinity + 2
    *{active > 4}[I'm active]I like to play football in Horsham park, it's great on sunny days! #Name_Me
        That sounds fun! Would love to see that! #Name_Freya
        ~affinity = affinity + 1
    *[Chill in my garden]When the weather allows it I like to read a book outside in my garden #Name_Me
        That's a nice thing to have. #Name_Freya
    *[Not really]Not really, I prefer staying home and watch movies most of the time #Name_Me
        That's a shame. #Name_Freya
        ~affinity = affinity - 2
- -> DONE
        
=== round_2 ===
Nice to see you in person! And right on time! #Name_Freya
Have you talked with the owner before coming here though? Wouldn't want to get on their wrong side.. #Name_Freya
    *[It's all by the book]Yes I had to take a reservation online before coming here don't worry #Name_Me
-Ah nice! Well, it's good to know that #Name_Freya
It's nice that you think about coming here and visit. #Name_Freya
Don't get me wrong, I love my friends here, but they're a bit too rowdy for my taste and don't have a lot of interesting things to say! #Name_Freya
What kind of people do you know and hang around with at home? #Name_Freya

    *{smart > 4}[Grill parties]I love to organize these barbeque parties at home and I have all sorts of friends coming. It's great fun and I'm sure we can share the food too! #Name_Me
        This sounds amazing! I can already imagine the smell of the grilled sausages! #Name_Freya
        ~affinity = affinity + 1
    *{likes_kids > 4}[Lots of children] Yes! We have a lot of children in our home of all ages, and I'm sure you will be able to find yourself friends among them! #Name_Me
        Children? Aren't they like small humans that don't listen to any rules and keep breaking stuff all the time? Huh.. #Name_Freya
        ~affinity = affinity - 2
    *{likes_dogs > 4}[Friends with dogs]We often meet with these friends of ours who have their own dogs. It's always great fun and you'll see you'll love playing with them too! #Name_Me
        Other dogs? And they play with each other at any time? That's amazing! #Name_Freya
        ~affinity = affinity + 2
    *[Watch a lot of TV]I usually prefer staying home and watch some TV after work. There are some great shows on display and this series I love to watch.. #Name_Me
        That sounds a little dull.. #Name_Freya
        ~affinity = affinity - 1
- -> DONE

=== round_3 ===
So nice to be outside of the shelter and see all these people! #Name_Freya
I even helped someone cross the street, they were very thankful! #Name_Freya
But others were crossing when the light was still red, not good! #Name_Freya
Especially some of the cats here, they keep lying in places where they aren't allowed, but people keep feeding them too, I don't understand.. #Name_Freya

    *{likes_cats < 4}[Cats are like that]Cats don't listen to any rule unfortunately, which is why I much prefer dogs! #Name_Me
        We at least listen to you guys! #Name_Freya
        ~affinity = affinity + 1        
        -> END
    *{likes_cats > 3}[Cats are like that]Cats don't listen to any rule unfortunately, but that is the way they are, you should respect them! #Name_Me
        Isn't that irritating to you though? #Name_Freya
        ~affinity = affinity - 1        
        -> END
    *[Relax]You know, rules are there just as an indication, and sometimes even to be broken. You don't have to obey them alll the time, it's fine. #Name_Me
        What are they here for then? #Name_Freya
        ~affinity = affinity - 1       
        -> END
        *[It's nice to help people]That's very nice of you to help elderly people cross the street. If everyone did that it would be even nicer here #Name_Me
        If I didn't help that person, who would? I had to! #Name_Freya
        ~affinity = affinity + 2        
        -> END



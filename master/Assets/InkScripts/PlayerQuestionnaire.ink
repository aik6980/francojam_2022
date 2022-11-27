INCLUDE PlayerState.ink


-> intro

===intro===
Welcome to Holbrook Animal Rescue! #Name_Blank
Thank you for deciding to rescue one of our dogs! #Name_Blank
We have developed a CHAT (Canine-to-Human Analyser and Translator) app that the dogs will use to communicate with you. #Name_Blank
You should be able to have full conversations with them! #Name_Blank
While all of them want a new home, some will be more suited to specific owners and environments than others. #Name_Blank
This quick questionnaire will help them (and you!) figure out the best match. #Name_Blank
Let's begin! #Name_Blank
-> question_1

===question_1===
Question 1: Do you already own a dog? #Name_Blank
*Yes #Name_Me
~has_dog = true
-> question_2
*No #Name_Me
~has_dog = false
-> question_2

===question_2===
Question 2: A cat jumps up on your lap. How do you respond? #Name_Blank
*I give it lots of pets! #Name_Me
~likes_cats = likes_cats + 3
-> question_3
*I give it a quick pet and let it sleep. #Name_Me
~likes_cats = likes_cats + 1
-> question_3
*I ignore it and continue what I was doing. #Name_Me
-> question_3
*I pick it up from my lap and put it back down from whence it came. #Name_Me
~likes_cats = likes_cats - 1
-> question_3
*I instinctively kick up my legs, sending it flying. #Name_Me
~likes_cats = likes_cats - 3
-> question_3

===question_3===
Question 3: A young child walks up to your dog and attempts to pet it. Your dog isn't the most comfortable around children. What do you do? #Name_Blank
*Introduce the child to the dog! Kids wouldn't hurt a fly! #Name_Me
~likes_kids = likes_kids + 3
-> question_4
*Subtly encourage the dog to say hello back with a sniff. Kids are generally fine. #Name_Me
~likes_kids = likes_kids + 1
-> question_4
*Let the dog decide how to respond. #Name_Me
-> question_4
*Discourage the child from getting too close. I don't trust them to behave. #Name_Me
~likes_kids = likes_kids - 1
-> question_4
*Unleash the dog and let it chase the child away! This park is for dogs! #Name_Me
~likes_kids = likes_kids - 3
-> question_4

===question_4===
Question 4: You've taken your dog out for a walk. You come across a junction with 4 walking routes. Which do you take? #Name_Blank
*The 7 mile route! The longer the better! #Name_Me
~likes_walks = likes_walks + 3
-> question_5
*The 5 mile route! Feels good to be outdoors. #Name_Me
~likes_walks = likes_walks + 1
-> question_5
*The 3 mile route! It's a happy medium. #Name_Me
-> question_5
*The 1 mile route! We're just out for a quick wander. #Name_Me
~likes_walks = likes_walks - 1
-> question_5
*I turn around and go home. This is far enough already. #Name_Me
~likes_walks = likes_walks - 3
-> question_5

===question_5===
Question 5: What level of education do you have? #Name_Blank
*I've got a PhD! #Name_Me
~smart = smart + 3
-> question_6
*I've got a degree! #Name_Me
~smart = smart + 1
-> question_6
*I've got A-Levels! #Name_Me
-> question_6
*I've got GCSEs! #Name_Me
~smart = smart - 1
-> question_6
*I've got the ability to speak! #Name_Me
~smart = smart - 3
-> question_6

===question_6===
Question 6: Your friend is attempting to convince you to participate in a triathlon. How do you respond? #Name_Blank
*I'm actually already competing! #Name_Me
~active = active + 3
-> question_7
*I'm convinced. Sign me up! #Name_Me
~active = active + 1
-> question_7
*We'll do some training and see if I feel ready. No promises. #Name_Me
-> question_7
*Yeah... you have fun with that. #Name_Me
~active = active - 1
-> question_7
*Say no and return to your you-shaped sofa imprint. #Name_Me
~active = active - 3
-> question_7

===question_7===
Question 7: You're watching TV when your dog brings you their trusty tennis ball. What do you do with it? #Name_Blank
*Get the rest of the toys and go outside to play with them all! #Name_Me
~playful = playful + 3
-> outro
*Play with the dog in the living room. You keep an eye on the TV. #Name_Me
~playful = playful + 1
-> outro
*Gently throw the ball back to them, then continue watching TV. #Name_Me
-> outro
*Give the ball back and promise to play later. #Name_Me
~playful = playful - 1
-> outro
*No tennis balls in this house! Time to get rid of it. #Name_Me
~playful = playful - 3
-> outro

===outro===
Thank you for your time! #Name_Blank
Have fun talking to our dogs! #Name_Blank

-> END
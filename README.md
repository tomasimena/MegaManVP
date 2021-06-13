# MegaManVP
Играта MegaMan, што претставува проект по визуелно програмирање, ја имплементиравме студентите: Ангела Алаѓозовска, Панче Стојанов и Тома Симена. 
Станува збор за игра што е наменета за двајца играчи - борачи кои се борат на сцената. Повремено на сцената се појавуваат бомба така што при допир се губи дел од животот на борачот што ја допрел, штит кој што го штити борачот одредено време или додека не дојде до контакт со бомба или не биде повреден од соборецот и срце со што при допир се зголемува животот на борачот што го допрел. Животот на борачот се прикажува во Progress Bar со зелена боја.
### Упатство за употреба
При старт на самата игра имаме можност да избереме почеток на самата игра, излез од играта и помош за тоа кои команди се користат за играње. Тоа може да го погледнеме на следната слика: 
![StartGame](https://user-images.githubusercontent.com/79939258/121813889-6f420a80-cc6e-11eb-8034-f5fb76b9333b.png)
Откако ќе се стартува играта, на сцената веќе ги имаме двајцата борачи а за време на борбата се појавуваат бомбата, штитот и срцето како што е опишано погоре. Играчите можат да се придвижуваат во сите можни насоки. За да се придвижат, едниот играч ги користи стрелките од тастатурата а другиот буквите W,A,S,D. При клик на quit game се овозможува излез од самата игра.
![201138738_264603282082947_8463836081926223802_n](https://user-images.githubusercontent.com/82347059/121818076-585ae280-cc85-11eb-9a70-de551a75512f.png)
При клик на help се појавува нова форма на која што е прикажано кои команди се користат за придвижување на борачите.
![131356176_555452728785350_2572363598319117989_n](https://user-images.githubusercontent.com/82347059/121818035-2184cc80-cc85-11eb-9588-6c21812ab374.png)
### Опишување на користените класи и функции
Главните податоци потребни за имплементација на оваа игра се чуваат во класата Warrior. Во оваа класа се наоѓаат функциите за движење на играчот.
![200846638_131080049094750_6037520856283279293_n](https://user-images.githubusercontent.com/82347059/121818487-b983b580-cc87-11eb-8405-3994f8a1785f.png)
Покрај оваа класа има и неколку други класи. Класата TwoPlayerGame каде што се имплементирани функции за играње на играта. Потоа класата StartGame каде што се наоѓаат функции за стартување на играта, класата Help, класата Player, Program, Warrior и други.



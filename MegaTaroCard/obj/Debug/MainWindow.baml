   M S B A M L   `   `   `  ����G  CMegaTaroCard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MegaTaroCardMegaTaroCard  5   	       MegaTaroCard.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MegaTaroCard     5   	     N� Title$  
MainWindow��5   	   $��610.5��6   $��985.5��6+    N� 
Background 5	      �� 5
   
    �� ImageSource$ .\fook\шар.png��6   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��475* �6   �� 5      $	��18* �6   .+�5   
   �� $��Главная��6   $��36(�6#   $��Center=�5      $��86,85,689,483q�61   
�������$��Bookman Old Style)�6[   $	��175��6z   �� 5   
   -   5        $��Задай вопрос��5      $��Bookman Old Style)�6A   $��14(�5      ���#D0F0C0$��82,194,711,387q�6(   �� 5   
   -   5        $#��Кармический код��5      ���#D0F0C0$��Bookman Old Style)�6@   $��14(�5      $��80,249,713,333q�60   �� 5   
   $J��DХочешь расшифровать натальную карту?��6   $��16(�6@   $��Center=�5      $��472,249,75,329q�6*   
�������$	��403��6U   $
��Bold"�6a    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ GreenYellow��6#      
BlurRadius$ 20Q�67      ShadowDepth$ 0Q�6G   5      �� 5   
   $H��BХочешь узнать ответ на любой вопрос?��6   $��16(�6@   $
��Bold"�6N   $��Center=�5      $��276,310,271,268q�6*   
�������$	��403��6V    5        5       $ GreenYellow��6#   $ 20Q�67   $ 0Q�6G   5"      �� 5#   
   $[��UХочешь попасть в мир астрологии и нумерологии?��6   $��16(�6J   $
��Bold"�6X   $��Center=�5$      $��436,374,111,204q�6*   
�������$	��403��6V    5%        5&      $ GreenYellow��6#   $ 20Q�67   $ 0Q�6G   5(      �� 5)   
   $��2��6   $��-10,-10,10,10q�6)   �� 5*   
   -   5        $��
Выход��5*      $��Bookman Old Style)�6;   $��14(�5+      ���#D0F0C0$��860,10,10,571q�60   5,      5-      
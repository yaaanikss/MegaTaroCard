   M S B A M L   `   `   `  ����G  CMegaTaroCard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MegaTaroCardMegaTaroCard  5          MegaTaroCard.gl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:MegaTaroCard     5        N� Title$  Карты Таро��5	      $��610.5��6   $��985.5��6)    N� 
Background 5
      �� 5   
    �� ImageSource$ .\fook\Небо.jpg��6   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   $��68��6*   �� 5      .+�5   
   �� $#��Кармический код��6   $��36(�6+   $��Center=�5      $��330,32,317,522q�61   
�������$	��339��6\   $��Bookman Old Style)�6h   $��2��6�   �� 5   
   $��1��6   $��20q�6$   ��5      �� 5      .R�5      � 5      ��5      �� 5      .R�5      �� $��10q�6    �� CornerRadius$ 10��6)   
����������#ccc$��1q�5   0   ._�5       �� .+�5!      �� $	��150��6A   $	��250��6M   $��UniformToFill=�5"   $   ��5!   $   �� *	ImagePath+5"   $   �� 5#      $��18(�6>   $��SemiBold"�5$   (   $��Center=�6>   $��5q�5%   (   ���#555��5#   (   �� *Name+5%   3   5&      5'      5(      5,      �� 5-   
   -   5        $��На главную��5-      ���#89AC76$��14(�6;   $
��Left=�6X   $��21��6s   $��	20,32,0,0q�6   $	��Top=�6�   $	��100��6�   $��Bookman Old Style)�6�   �� 5.   
   -   5         ��Name$ AnswerOutput��5.      $
��Wrap=�6*   $��245,105,241,0q�6>   $��16(�6U   $	��271��6c   $	��Top=�6p   $��1��6�   ���	#FFFDFDFD$��Bookman Old Style)�6�   �� 5/   
   -   5         ��Name$ QuestionInput��5/      $��32��6)   $��93,93,317,0q�65   $	��Top=�6J   6b   �� 50   
   -   5        ���#D0F0C0$6��0Получить магический ответ��52      $��32��53      $��710,93,66,0q�54      $	��Top=�55      $��Bookman Old Style)�57      $��14(�58      �� 59   
   -   5         ��Name$ LoadingImage��59      $��./fook/loading.gif��6&   $	��100��6B   $	��200��6N   $y�	Collapsed=�6[   $��3��6r   $��Center=�6�   $��Center=�6�   $��440,240,446,10q�6�   5;      5<      
   M S B A M L   `   `   `  ����L  HHCI projekat 2020, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:HCI_projekat_2020HCI_projekat_2020  5   	   K*clr-namespace:HCI_projekat_2020.ValidacijaHCI_projekat_2020.Validacija  5   	   ?$clr-namespace:HCI_projekat_2020.HelpHCI_projekat_2020.Help  5   	        HCI_projekat_2020.DodajTip   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:HCI_projekat_2020     5   	   <valid*clr-namespace:HCI_projekat_2020.Validacija     5   	   5help$clr-namespace:HCI_projekat_2020.Help     5   	   -   5          � 
ResizeMode$  CanMinimize=�5
   	    � Title$ DodajTip��5   	   $	��449��6   $��520.765��6'    � WindowStartupLocation$ CenterScreen=�5   	   )  #HCI_projekat_2020.Help.HelpProvider   HelpKey$	 Tip��6E    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.Help��5      6<   .��5      � 
�������$��0,0,-8,0q�6"    J� RenderTransformOrigin$ 
0.742,0.53&�64   .+�5   
   �� -   5        $��label1��5   \   $��Oznaka:��6   $��23��6"   $
��Left=�6.   $��	24,41,0,0q�6I   $	��Top=�6j   $��Italic$�6�   �� 5   
   -   5        $��label2��5   [   $��Naziv:��6   $��28��6!   $
��Left=�6-   $��	24,76,0,0q�6H   $	��Top=�6i   $��Italic$�6�   �� 5   
   -   5        $��label3��5   [   $��Opis:��6   $��28��6    $
��Left=�6,   $��
24,113,0,0q�6G   $	��Top=�6i   $��Italic$�6�   �� 5   
   -   5        $��label4��5   ~   $��Dodavanje tipa događaja��6   $��Italic$�62   $��28��6E   $
��Left=�6Q   $��24,0,0,0q�6l   $	��Top=�6�   $	��192��6�   $
��Bold"�6�   �� 5   
   -   5        $��textBox1��5   L   $��23��6   $
��Left=�6   $��	82,43,0,0q�69   $	��Top=�6\   $	��120��6t   .��6�   .��5      ��  �� Path$ oznaka�6    �� UpdateSourceTrigger$ PropertyChanged=�6$   	 �� ValidationRules	 5      3   -HCI_projekat_2020.Validacija.ValidacijaOznaka  5      1  +HCI_projekat_2020.Validacija.OznakaPostoji1  5      7  1HCI_projekat_2020.Validacija.ValidacijaOznakaBroj  5      5       
 =� ErrorTemplate
 5!      �� 5"      .R�5#      �� .+�5$      ��  ��Name$ textBox1��64   �� 5%      $
��Bold"�6F   $��10(�6X   
���   ���6$   �� *[0].ErrorContent+6f   5&      5'      .��5(   (   5)      �� 5+   
   -   5        $��textBox2��5+   N   $	��105��6   $
��Left=�6   $��
82,118,0,0q�6:   $	��Top=�6^   $	��269��6v   .��6�   .��5,      �� $
 opis�6   $ PropertyChanged=�6"   	 5-      8  2HCI_projekat_2020.Validacija.ValidacijaPraznoPolje  5.      50      
 51      �� 52      .R�53      ]� .+�54      �� $ textBox2��64   �� 55      $
��Bold"�6$   $��15(�66   
���   �!6\   56      57      .��58   (   59      �� 5;   
   -	   5        $��textBox3��5;   L   $��23��6   $
��Left=�6   $��	82,80,0,0q�69   $	��Top=�6\   $	��120��6t   .��6�   .��5<      �� $ naziv�6   $ PropertyChanged=�6#   	 5=        5>      5@      
 5A      �� 5B      .R�5C      ]� .+�5D      �� $ textBox3��64   �� 5E      $
��Bold"�6$   $��15(�66   
���   �!6\   5F      5G      .��5H   (   5I      �� 5M   
   -
   5        $��button1��5M   i   $��Izaberite ikonicu��6   $��23��6-   $
��Left=�69   $��397,146,0,0q�6T   $	��Top=�6x   $��96��6�   6�   �� 5N   
   -   5         ��Name$ textBox1_Copy��5N   N   $��23��6   $
��Left=�6   $��397,118,0,0q�69   $	��Top=�6e   $��98��6}   {�.  $��Podrazumevana...��6�   �� 5O   
   -   5         ��Name$ image1��5O      $
��Left=�6    $��70��6;   $��
397,43,0,0q�6G   $	��Top=�6[   $��98��6s   $��	noimg.png��6~   $��Uniform=�6�   &   System.Windows.Controls.DataGrid  5Q   
   -   5          Name$ dataGrid��5Q         SelectionMode$ Single=�6%      
IsReadOnly .    CanUserAddRows .     AutoGenerateColumns .  $
��Left=�6�   $��
24,244,0,0q�6�   $	��343��6�   $	��107��6�   $	��Top=�6�      	RowHeight$ 25Q�6  ��6�   �� *TipDogadjaja+   Columns 5R      0  *System.Windows.Controls.DataGridTextColumn  5S      ,	  &System.Windows.Controls.DataGridColumn 	  Header$ Oznaka��6%   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 65   �� *oznaka+  5T      $ Naziv��6%    64   �� *naziv+  5U      $
 Opis��6%    63   �� *opis+  5V      $ Ikonica��6%    66   �� *	ikonica+5X      �� 5Z   
   -   5         ��Name$ button2_Copy��5Z   q   $��Dodaj��6   $��23��6!   $
��Left=�6A   $��397,244,0,0q�6\   $	��Top=�6�   $��96��6�   �� 5[   
   -   5        $ button3_Copy��5[   `   $��Odustani��6   $��23��6$   $
��Left=�60   $��397,328,0,0q�6K   $	��Top=�6v   $��96��6�   6�   �� 5\   
   -   5        $ button2_Copy1��5\   ^   $��Izmeni��6   $��23��6"   $
��Left=�6.   $��397,272,0,0q�6I   $	��Top=�6u   $��96��6�   6�   �� 5]   
   -   5        $ button2_Copy2��5]   ]   $��Obrši��6   $��23��6!   $
��Left=�6-   $��397,300,0,0q�6H   $	��Top=�6t   $��96��6�   $ 0.5,0.5&�6�   6�   �� 5_   
   -   5        $ button8��5_      $��471,379,10,3q�6"   $��0q�68   ��5`      �� 5a       j� Stretch$
 Fill=�6    �� ImageSource$% pack://application:,,,/help.png��6,    j� 
AlignmentY$ Center=�6Z    j� 
AlignmentX$ Center=�6n   5c      5e      5f      
   M S B A M L   `   `   `  ����L  HHCI projekat 2020, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:HCI_projekat_2020HCI_projekat_2020  5   	   K*clr-namespace:HCI_projekat_2020.ValidacijaHCI_projekat_2020.Validacija  5   	   ?$clr-namespace:HCI_projekat_2020.HelpHCI_projekat_2020.Help  5   	   $    HCI_projekat_2020.DodajEtiketu   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:HCI_projekat_2020     5   	   <valid*clr-namespace:HCI_projekat_2020.Validacija     5   	   5help$clr-namespace:HCI_projekat_2020.Help     5   	   -   5          � 
ResizeMode$  CanMinimize=�5
   	    � Title$ DodajEtiketu��5   	   $��466.021��6   $��526.203��6/    � WindowStartupLocation$ CenterScreen=�5   	   )  #HCI_projekat_2020.Help.HelpProvider   HelpKey$ Etiketa��6E    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.Help��5      6<   .��5      � -   5        $��grid123��5      
�������.+�5   
   �� -   5        $��label4��5   X   $��Dodavanje nove etikete��6   $��28��61   $
��Left=�6=   $	��Top=�6f   $	��265��6~   $
��Bold"�6�   $��Italic$�6�   $��24,0,0,0q�6�   �� 5   
   -   5        $��label1��5   \   $��Oznaka:��6   $��28��6"   $
��Left=�6.   $��	24,43,0,0q�6I   $	��Top=�6j   $��Italic$�6�   �� 5   
   -   5        $��label2��5   Z   $��Boja:��6   $��28��6    $
��Left=�6,   $��	25,82,0,0q�6G   $	��Top=�6h   $��Italic$�6�   �� 5   
   -   5        $��label3��5   [   $��Opis:��6   $��28��6    $
��Left=�6,   $��
25,0,0,247q�6G   $��Bottom=�6i   $��Italic$�6�    J� RenderTransformOrigin$ 0.472,2.143&�6�   �� 5   
   -   5        $��textBox1��5   L   $��23��6   $
��Left=�6   $��	82,47,0,0q�69   $	��Top=�6x   $	��120��6�   .��6�   .��5      ��  �� Path$ oznaka�6    �� UpdateSourceTrigger$ PropertyChanged=�6$   	 �� ValidationRules	 5      3   -HCI_projekat_2020.Validacija.ValidacijaOznaka  5      0  *HCI_projekat_2020.Validacija.OznakaPostoji  5      7  1HCI_projekat_2020.Validacija.ValidacijaOznakaBroj  5      5      
 =� ErrorTemplate
 5       �� 5!      .R�5"      �� .+�5#      ��  ��Name$ textBox1��64   �� 5$      $
��Bold"�6F   $��10(�6X   
���   ���6$   �� *[0].ErrorContent+6f   5%      5&      .��5'   (   5(      �� 5*   
   -	   5        $��textBox2��5*   N   $	��114��6   $
��Left=�6   $��
82,129,0,0q�6:   $	��Top=�6w   $	��269��6�   .��6�   .��5+      �� $
 opis�6   $ PropertyChanged=�6"   	 5,      8  2HCI_projekat_2020.Validacija.ValidacijaPraznoPolje  5-      5/      
 50      �� 51      .R�52      ]� .+�53      �� $ textBox2��64   �� 54      $
��Bold"�6$   $��15(�66   
���   �!6\   55      56      .��57   (   58      �� 5:   
   -
   5        $��button1��5:   e   $��Izaberite boju��6   $��24��6*   $
��Left=�66   $��
207,86,0,0q�6Q   $	��Top=�6t   $��94��6�   6�   &   System.Windows.Controls.DataGrid  5<   
   -   5          Name$ dataGrid��5<         SelectionMode$ Single=�6%      
IsReadOnly .    CanUserAddRows .     AutoGenerateColumns .  $
��Left=�6�   $��
24,264,0,0q�6�   $	��351��6�   $	��107��6�   $	��Top=�6�   ��6<   �� *EtiketaDogadjaja+   Columns 5=      0  *System.Windows.Controls.DataGridTextColumn  5>      ,	  &System.Windows.Controls.DataGridColumn 	  Header$ Oznaka��6%   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 65   �� *oznaka+  5?      $
 Boja��6%    63   �� *boja+  5@      $
 Opis��6%    	  Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6L    63   �� *opis+6L   5B      �� 5D   
   -   5         ��Name$ button2_Copy��5D   ]   $��Dodaj��6   $��23��6!   $
��Left=�6-   $��406,264,0,0q�6H   $	��Top=�6s   $��94��6�   6�   �� 5E   
   -   5        $ button3_Copy��5E   `   $��Odustani��6   $��23��6$   $
��Left=�60   $��406,348,0,0q�6K   $	��Top=�6v   $��94��6�   6�   �� 5F   
   -   5        $ button2_Copy1��5F   ^   $��Izmeni��6   $��23��6"   $
��Left=�6.   $��406,292,0,0q�6I   $	��Top=�6u   $��94��6�   6�   �� 5G   
   -   5        $ button2_Copy2��5G   ]   $��Obrši��6   $��23��6!   $
��Left=�6-   $��406,320,0,0q�6H   $	��Top=�6t   $��94��6�   $ 0.5,0.5&�6�   6�   � 5H   
   -   5        $��grid1��5H      ���	#FFFFFFFF$
��Left=�64   $��24��6O   $��	82,86,0,0q�6[   $	��Top=�6n   $	��120��6�    � ColumnDefinitions 5I      �� 5J      $	��97* �6#   �� 5K      $	��16* �6#   �� 5L      $��7* �6#   .+�5N      �� 
���   �$��2q�6)   $��3��6=   5O      �� 5Q   
   -   5        $ button8��5Q      $��469,393,4,5q�6"   $��0q�67   ��5R      �� 5S       j� Stretch$
 Fill=�6    �� ImageSource$% pack://application:,,,/help.png��6,    j� 
AlignmentY$ Center=�6Z    j� 
AlignmentX$ Center=�6n   5U      5W      5X      
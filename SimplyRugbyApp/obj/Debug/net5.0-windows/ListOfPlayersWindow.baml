   M S B A M L   `   `   `  ����I  ESimplyRugbyApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SimplyRugbyAppSimplyRugbyApp  5   	   (    "SimplyRugbyApp.ListOfPlayersWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:SimplyRugbyApp     5   	     � Title$   Simple Rugby - Player list��5   	   $	��570��6,   $	��520��69    � 
ResizeMode$ NoResize=�6E    � WindowStartupLocation$ CenterScreen=�6[   .��5      >�  � 	Resources 5   
      SimplyRugbyApp.ClubDetails   theData 
 level2 �� StringFormat �� Path 
 level1 �� ItemTemplate �� ItemsSource��%r  &	        &	      &	 �     7    5      6    �� 5      .R�5      �� ��5      `� 5      $ {0} - {1} {2}��6'   .1�5      �� $ 	SRUNumber�6&   �� 5      $ 	FirstName�6&   �� 5      $ LastName�6&   5      5      5      �� 5      8    5   #   �� *	Players+.R�5      �� ��6   �� $
 Name�5      5       .��5#   
   � -   5         �Name$ Gr_elements��5#      ��5$      �� 5%      	 �� ImageSource$	 img/logo.png��6   .+�5'      R� -   5        
 R�Name$
 Tv_listOfPlayers��5'      $��30,30,240,30q�61   #��[ 5(      #��[  5)      �� 5+      -   5         ��Name$ Btn_ViewPlayerDetails��5+      $��View player details��64   $
��Left=�6R   $��45��6m   $��
300,30,0,0q�6y   $	��Top=�6�   $	��180��6�   6�   �� 5,      -   5        $ Btn_AddPlayer��5,      $��Add new player��6,   $
��Left=�6E   $��45��6`   $��
300,90,0,0q�6l   $	��Top=�6�   $	��180��6�   6�   �� 5-      -   5        $ Btn_ListOfEmails��5-      $��List of e-mails��6/   $
��Left=�6I   $��45��6d   $��300,150,0,0q�6p   $	��Top=�6�   $	��180��6�   6�   �� 5.      -   5         ��Name$ Tb_SruSearch��5.      $
��Left=�6,   $��300,360,0,0q�6G    �� TextWrapping$
 Wrap=�6\   $	��Top=�6p   $	��180��6�   $��25��6�   4  .System.Windows.Automation.AutomationProperties   HelpText$ 
SRU number��6�   $��20(�6�   �� 5/      -   5        $ 
Btn_Search��5/      $��Search��6)   $
��Left=�6:   $��45��6U   $��300,400,0,0q�6a   $	��Top=�6v   $	��180��6�   6�   �� 50      -   5        $ Btn_Exit��50      $
��Exit��6'   $
��Left=�66   $��45��6Q   $��300,465,0,0q�6]   $	��Top=�6r   $	��180��6�   6�   �� 51      -	   5         ��Name$ Tbl_FindPlayer��51      $
��Left=�60   $��300,330,0,0q�6K   $
��Wrap=�6`   $	��Top=�6t   $	��180��6�   $��25��6�    �� TextAlignment$
 Left=�6�   $
��Bold"�6�   $��14(�6�   
��������� 6�   $�Find Player��6�   �� 6   � Language$ en-gb�6
  $� (SRU number):��6  64  52      53      54      
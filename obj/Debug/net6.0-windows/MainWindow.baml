   M S B A M L   `   `   `  ����G  CPhoneContact, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:P1PhoneJohanP1PhoneJohan  5   	       P1PhoneJohan.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:P1PhoneJohan     5   	   -   5          � Title$  	Kontakter��5
   	   $	��450��6   $	��800��6(   .��5      � .+�5   
   ]� .+�5      A� $	��Top=�6    A� Rows$ 1��6/   .+�5      �� -   5         ��Name$ SortItemComboBox��5      $��
10,0,-66,0q�66   $��20��6J   .@�5      ��  �� 
IsSelected$
 True��6#   .��65   
Förnamn5      �� 5      .��6#   	Efternamn5      5      �� 5      -   5        $ SortOrderComboBox��5      $��71,0,-150,0q�67   $��20��6L   .@�5      �� $
 True��6#   .��65   
Fallande5      �� 5      .��6#   
Stigande5      5      �� 5      $��165,0,-15,0q�6    J� RenderTransformOrigin$ 0.905,0.495&�5      .��6<   Sök5!      �� 5"      -   5         ��Name$ SearchTextBox��5"      $��20��5#      $��15,0,0,0q�5$      5%      5&      A� 5'      $��Bottom=�6   $ 1��62   .+�5(      �� $��0,0,32,0q�6   .��6*   
Förnamn5*      �� 5+      -   5        $ FirstNameTextBox��5+      $��20��5,      $��
-32,0,16,0q�5-      �� 5.      $��
-16,0,41,0q�6   $��	Efternamn��5/      �� 50      -   5        $ LastNameTextBox��50      $��20��51      $��
-41,0,26,0q�52      �� 54      $��
-26,0,62,0q�6   .��6,   	Telefon65   �� 55      -   5        $ PhoneNumberTextBox��55      $��20��56      $��
-62,0,47,0q�57      �� 59      -   5        $ SelectColorComboBox��59      $��
-42,0,42,0q�69   $��20��6M   �� 5;      -	   5         ��Name$ 	AddButton��5<      $��20��5>      $��
Lägg till��5?      $��
-37,0,28,0q�5@      �� 5A      -
   5        $��20��5B      $��Ta bort��5C      $��
-23,0,10,0q�5D      5E      �� 5F      -   5         ��Name$ ContactsListBox��5F      $	��792��5G      $	��376��5H      ��5J      �� 5K       �� 
TargetType" ��6   .�5L      �� 	 �� Property	 � ��
 �� Value$
 Stretch=�6G   5M      ��5O      �� 5P      .R�5Q      �� 
���   �$��2q�5S       �� CornerRadius$ 5��5T      ��5Q   !   �� *Color+._�5U      �� �� 5V      �6"   �� *	FirstName+ �� 5W      �6"   �� *
LastName+ �� 5X      $�:��6"    �� 5Y      �6"   �� *PhoneNumber+5Z      5[      5\      5^      5_      5`      5a      
# Roblox Shader Patch

Patches early 2007 and mid 2007 clients to use unused shader code

<img width="640" height="393" alt="blog roblox (1)" src="https://github.com/user-attachments/assets/bb81e79a-bed6-499e-a2a9-488006c04afc" />
<br>(Screenshot by Telamon, 2006, hosted on Roblox's blog in 2017 before being deleted sometime this year)

## How does it work?

It modifies 2 values in the Roblox executable, one for depth of field, the other for bloom.
<br>To enable it, the program sets the value to 01
<br>and to disable it, it sets it to 00.
<br>
<br>To know what value to edit, it uses offsets.

## What are the offsets for DOF and bloom?

| Effect | Early 2007 | Mid 2007 |
| --- | --- | --- |
| Depth of Field | F240E | 10295E |
| Bloom | F2401 | 102951 |

## Comparison
<img width="1919" height="1079" alt="image" src="https://github.com/user-attachments/assets/fb23c226-3a5b-4a27-b862-26df503e1f8f" />

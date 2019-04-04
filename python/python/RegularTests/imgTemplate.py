import re

text = '''Et voluptatem autem saepe sunt et. %%img:32981ba2-d023-4e86-9608-5c04f10910c0:left:w=200%% Animi nulla facere veniam nemo delectus. Distinctio omnis dolore soluta dolor velit eaque.

%%img:32981ba2-d023-4e86-9608-5c04f10910c0:center:h=200%%

Voluptas eum %%img:32981ba2-d023-4e86-9608-5c04f10910c0:right%% perspiciatis %%img:%% repellat dolorem nemo qui. Et maxime facere aliquid. Velit reprehenderit provident doloribus ad ullam animi iure. In architecto ipsa molestias sunt accusantium facilis quasi qui.'''

if __name__ == '__main__':
    p = re.compile('\%\%img:[A-Za-z0-9-]+[A-Za-z0-9:=]*\%\%')
    m = p.findall(text)
    print(m)

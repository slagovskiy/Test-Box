import antispam
import os
from transliterate import translit


m = antispam.Model(os.path.join(os.path.dirname(os.path.abspath(__file__)), "model.dat"))

str = [
    'Сотрудники Независимой исследовательской организации NORC в Чикагском университете утверждают: пессимизм по '
    'поводу старения с возрастом сменяется оптимизмом. Ослабевают страхи перед болезнями, утратой дееспособности и '
    'потерей памяти. Читайте об этом подробнее на сайте <a href=http://tvoi-noski.ru>tvoi-noski.ru</a>',
    'Writer: Getaway Lounge Bali is one of the vital lovely islands in the south pacific. Backups may be '
    'protected with up to 256-bit AES encryption - thats a 32 character password in case you have been wondering, '
    'so the usual pets identify probably wont cut it.<a href=http://buy-ibuprofen.com/>wirkzeit ibuprofen</a>'
    'Search an online jewelry shop before you make your trip to the jewelry expert so that you know what you are '
    'looking for.A well build infrastructure and booming economy attracts buyers from all around the world to put '
    'money into Property in Greece.<a href=http://buy-flagyl.com/>flagyl over the counter uk</a>That is an strategy '
    'that many individuals take however it might not end in you getting the very best price.Whats a lot better is to '
    'scrub tender toys by hand - children can be part of on this job, and so they normally enjoy it. '
    'http://grandviewlandscape.com/help-writing-a-grant-proposal fktrpr94f Tata Motor has effectively designed its '
    'automobiles which suits to the necessities of the Indian customers.Technically,relocating towards be the use '
    'taking towards do with oscillators are fundamentally Alright for investing within just north the '
    'us congestion stages.',
    'Привет всем участникам! класный у вас сайт! Нашел интересную базу кино: <a href=http://kinofly.net/>'
    'Бесплатно лучшие семейные фильмы</a> Тут: http://kinofly.net/serialy/2550-smotrite-gannibal-onlayn-chto-ozhidat-'
    'ot-odinnadcatoy-serii-vtorogo-sezona.html <b> Смотреть сериал Смотрите «Ганнибал» онлайн: что ожидать от '
    'одиннадцатой серии второго сезона? онлайн бесплатно </b> Тут: <a href=http://kinofly.net/melodrama/1382-'
    'arifmetika-podlosti-2011.html> ',
    'Смотреть Арифметика подлости (2011) онлайн бесплатно </a> '
    'Здесь: http://kinofly.net/news/9535-v-prokat-vyhodyat-luchshie-korotkometrazhki-festivalya-new-vision.html '
    'Здесь: http://kinofly.net/uzhasy/ <b> Лучшие ужасы 2017 смотреть </b> Здесь: '
    '<a href=http://kinofly.net/fantastika/> Лучшие фантастика 2017 в хорошем качестве hd 720 </a> Тут: '
    '<a href=http://kinofly.net/fantastika/> Новинки смотреть онлайн лучшая фантастика </a> '
    'Новинки смотреть онлайн лучшая фантастика',
    'Buy viagra!',
    'Привет! Отличный сайт!',
    'Первое удобнее всего. Но хотя бы пару раз на тестовой базе попробовать не мешает',
    'В интернете можно приобрести качественную одежду для ребенка по привлекательным ценам, не выходя из дома. '
    'Так же в таких магазинах регулярно проходят различные акции и распродажи сезонного товара. Подробнее читайте '
    'на сайте <a href=http://dettka.com>dettka.com</a>',
    'Поскольку, как говорит автор, эти товарищи (ОПГ) хорошо планируют свои набеги, то возможно так же хорошо '
    'знают, что не имеют права делать охранники и при попытке заломать/задержать сразу же накатают заяву.',
    'Howdy! I know this is kinda off topic but I was wondering which blog platform are you using for this website? '
    'Im getting sick and tired of Wordpress because Ive had issues with hackers and Im looking at options for '
    'another platform. I would be fantastic if you could point me in the direction of a good platform.'
    '[url=http://viagrapego.com/]medix[/url] viagra condoms<a href="viagrawithoutadoctorsntx.com/">free viagra</a>',
    'free viagra',
    'Банкротство',
    'Кредиторы',
    'Коллекторы',
    'Дебет кредит',
    'Минимальный платеж',
    'Выплата',
    'Процентная ставка',
    'Долг',
    'Рефинансирование',
]

for s in str:
    s = translit(s, 'ru', reversed=True)
    print(s)
    print(antispam.score(s), antispam.is_spam(s))


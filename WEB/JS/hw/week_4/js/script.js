class Phone{
    constructor(brand, model, price, ram, mem, imgUri){
        this.brand = brand
        this.model = model
        this.price = price
        this.ram = ram
        this.mem = mem
        this.imgUri = imgUri
    }
}

let phonesArray = [
    new Phone('Samsung', 'Galaxy A30', 7500, 4, 64, 'images/samsung_a305_galaxy_a30_06.jpg'),
    new Phone('Samsung', 'Galaxy S10', 29000, 8, 128, 'images/samsung_galaxy_s10_8128gb_red_1.jpg'),
    new Phone('Samsung', 'Galaxy A10', 3700, 2, 32, 'images/_samsung_a105_galaxy_a10_232gb_black_01.jpg'),
    new Phone('Xiaomi', 'Mi 9', 14000, 6, 128, 'images/xiaomi_mi_9_6128gb_piano_black_1.jpg'),
    new Phone('Xiaomi', 'Redmi Note 7', 6700, 4, 128, 'images/xiaomi_redmi_note_7_464gb_neptune_blue_1_1.jpg'),
    new Phone('Xiaomi', 'Redmi 5', 3800, 3, 32, 'images/_xiaomi_redmi_5_3-32gb_gold_2_1.jpg'),
    new Phone('Samsung', 'Galaxy A30', 7500, 4, 64, 'images/samsung_a305_galaxy_a30_06.jpg'),
    new Phone('Samsung', 'Galaxy S10', 29000, 8, 128, 'images/samsung_galaxy_s10_8128gb_red_1.jpg'),
    new Phone('Samsung', 'Galaxy A10', 3700, 2, 32, 'images/_samsung_a105_galaxy_a10_232gb_black_01.jpg'),
    new Phone('Xiaomi', 'Mi 9', 14000, 6, 128, 'images/xiaomi_mi_9_6128gb_piano_black_1.jpg'),
    new Phone('Xiaomi', 'Redmi Note 7', 6700, 4, 128, 'images/xiaomi_redmi_note_7_464gb_neptune_blue_1_1.jpg'),
    new Phone('Xiaomi', 'Redmi 5', 3800, 3, 32, 'images/_xiaomi_redmi_5_3-32gb_gold_2_1.jpg')
]

Vue.component('phone-card', {
	props: ['id', 'phone-data'],
	template: `<div class="card" style="width: 18rem;">
		<img v-bind:src="phoneData.imgUri" class="card-img-top" alt="...">
		<div class="card-body">
			<h4 class="card-title">{{phoneData.price}} грн</h4>
			<h5 class="card-title">{{phoneData.brand}} {{phoneData.model}}</h5>
			<p class="card-text">
			Оперативная память: {{phoneData.ram}} Гб
			<br>
			Основная память: {{phoneData.mem}} Гб
			</p>
			<a href="#" v-bind:value="id" class="btn btn-primary" @click="toCart()">Положить в корзину</a>
		</div>
	</div>`,
	methods: {
		toCart: function(){
			let cartArray = cart.getPhones()
			cartArray.push(this.id)
			cart.setPhones(cartArray)
            cart.updateCount()
            cart.updateSum()
		}
	}
})

Vue.component('phone-in-cart', {
    props: ['index'],
    template: `<div><img v-bind:src="phone.imgUri" alt="..."><span>{{phone.brand}} {{phone.model}}</span></div>`,
    computed: {
        phone(){ return phonesArray[this.index]; }
    }
})

let cart = new Vue({
    el: '#cart',
    computed: {
        phones: function(){ return this.getPhones() }
    },
    methods: {
        clear: function(){
            this.setPhones([])
            this.updateCount()
            this.updateSum()
        },
        setPhones: function(cart){ localStorage.setItem('cart', JSON.stringify(cart)) },
        getPhones: function(){
            let ls = JSON.parse(localStorage.getItem('cart'))
            return (ls === null)?[]:ls
        },
        getSum: function(){
            let sum = 0
            for(let i of this.getPhones()){
                sum += phonesArray[i].price
            }
            
            return sum + ' грн'
        },
        updateCount: function(){ $('#cart-count').text(this.getPhones().length + ' шт') },
        updateSum: function(){ $('#sum').text(this.getSum()) },
        removePhone: function(index){
            let array = this.getPhones()
            array.splice(index, 1)
            this.setPhones(array)
            this.updateCount()
            this.updateSum()
        },
        getPhonesList: function(){
            let cartPhones = $('#cart-phones')
            cartPhones.empty()
            
            let cnt = 0;
            for(let i of this.getPhones()){
                let phone = document.createElement('li')
                $(phone).append(`<span onclick="cart.removePhone(${cnt})" class="glyphicon glyphicon-remove" aria-hidden="true" value=${cnt}></span><a href="#"><img src="${phonesArray[i].imgUri}" alt="..."><span>${phonesArray[i].brand} ${phonesArray[i].model}</span></a>`)
                $(cartPhones).append(phone)
                
                cnt++;
            }
            if(this.getPhones().length > 0){
                $(cartPhones).append(`<li onclick="cart.clear()"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span><a href="#">Очистить корзину</a></li>`)
                this.addTextToPurchaseDialog()
                $(cartPhones).prepend(`<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">Купить</button>`)
            }
            else $(cartPhones).append('<span>Корзина пуста</span>')
        },
        addTextToPurchaseDialog: function(){
            let purchase = $('#purchase')
            $(purchase).empty()
            
            let cnt = 1
            for(let i of this.getPhones()){
                $(purchase).append(`<div>${cnt}<img src="${phonesArray[i].imgUri}"><span>${phonesArray[i].brand} ${phonesArray[i].model}</span></div>`)
                cnt++
            }
            $(purchase).append(`<h3>На сумму: <span>${this.getSum()}</span></h3>`)
        }
    }
})

new Vue({
	el: '#shop',
	data: {
		phones: phonesArray
	},
    methods: {
        searchButtonShowHide: function(){
            let searchBar = $('#search-bar')
            let display = ($(searchBar).css('display') === 'block') ? 'none' : 'block'
            $(searchBar).css('display', display)
            
            let brands = jQuery.unique(phonesArray.map(o => o.brand).sort())
            
            $('#filter-brand').empty()
            $('#filter-brand').append('<option value=""></option>')
            for(let brand of brands)
                $('#filter-brand').append(`<option value="${brand}">${brand}</option>`)
        },
        searchAndFilter: function(){
            let searchText = $('#search-input').val()
            let brand = $('#filter-brand').val()
            let priceFrom = parseInt($('#filter-price-from').val())
            let priceTo = parseInt($('#filter-price-to').val())
            
            //Фильтр
            if(brand !== '')
                this.phones = phonesArray.filter(o => { return o.brand === brand })
            else this.phones = phonesArray
                
            this.phones = this.phones.filter(o => {
                return (o.price >= priceFrom && o.price <= priceTo)
            })
            
            //Поиск
            if(searchText != ''){
                if(this.phones.length === 0) this.phones = phonesArray
                
                this.phones = this.phones.filter(function(o){
                    let isFound = false
                    for(let val of Object.values(o)){
                        if(val.toString().includes(searchText)){
                            isFound = true
                            break
                        }
                    }

                    return isFound === true
                })
            }
//            else this.phones = phonesArray
        }
    }
})
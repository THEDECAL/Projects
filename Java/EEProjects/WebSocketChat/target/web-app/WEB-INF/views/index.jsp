<%@ page contentType="text/html;charset=UTF-8" language="java" isELIgnored="false" %>
<html>
<head>
    <title>Чат</title>
    <jsp:include page="templates/includes.jsp" />
</head>
<body>
<div class="container">
    <h3 class=" text-center">Чат</h3>
    <div class="messaging">
        <div class="inbox_msg">
            <div class="inbox_people">
                <div class="headind_srch">
                    <div class="recent_heading">
                        <h4>Пользователи</h4>
                    </div>
                    <div class="srch_bar">
                        <div class="stylish-input-group">
                            <input type="text" class="search-bar" placeholder="Введите никнэйм..." id="userName">
                            <span class="input-group-addon">
                                        <button id="btnConnect" type="button">Подключится<i class="fa fa-search" aria-hidden="true"></i>
                                        </button>
                                    </span>
                        </div>
                    </div>
                </div>
                <div id="users" class="inbox_chat">
<%--                    <div class="chat_list active_chat">--%>
<%--                        <div class="chat_people">--%>
<%--                            <div class="chat_img"><img src="https://ptetutorials.com/images/user-profile.png"--%>
<%--                                                       alt="sunil"></div>--%>
<%--                            <div class="chat_ib">--%>
<%--                                <h5>Sunil Rajput <span class="chat_date">Dec 25</span></h5>--%>
<%--                                <p>Test, which is a new approach to have all solutions--%>
<%--                                    astrology under one roof.</p>--%>
<%--                            </div>--%>
<%--                        </div>--%>
<%--                    </div>--%>
<%--                    <div class="chat_list">--%>
<%--                        <div class="chat_people">--%>
<%--                            <div class="chat_img"><img src="https://ptetutorials.com/images/user-profile.png"--%>
<%--                                                       alt="sunil"></div>--%>
<%--                            <div class="chat_ib">--%>
<%--                                <h5>Sunil Rajput <span class="chat_date">Dec 25</span></h5>--%>
<%--                                <p>Test, which is a new approach to have all solutions--%>
<%--                                    astrology under one roof.</p>--%>
<%--                            </div>--%>
<%--                        </div>--%>
<%--                    </div>--%>
<%--                    <div class="chat_list">--%>
<%--                        <div class="chat_people">--%>
<%--                            <div class="chat_img"><img src="https://ptetutorials.com/images/user-profile.png"--%>
<%--                                                       alt="sunil"></div>--%>
<%--                            <div class="chat_ib">--%>
<%--                                <h5>Sunil Rajput <span class="chat_date">Dec 25</span></h5>--%>
<%--                                <p>Test, which is a new approach to have all solutions--%>
<%--                                    astrology under one roof.</p>--%>
<%--                            </div>--%>
<%--                        </div>--%>
<%--                    </div>--%>
<%--                    <div class="chat_list">--%>
<%--                        <div class="chat_people">--%>
<%--                            <div class="chat_img"><img src="https://ptetutorials.com/images/user-profile.png"--%>
<%--                                                       alt="sunil"></div>--%>
<%--                            <div class="chat_ib">--%>
<%--                                <h5>Sunil Rajput <span class="chat_date">Dec 25</span></h5>--%>
<%--                                <p>Test, which is a new approach to have all solutions--%>
<%--                                    astrology under one roof.</p>--%>
<%--                            </div>--%>
<%--                        </div>--%>
<%--                    </div>--%>
<%--                    <div class="chat_list">--%>
<%--                        <div class="chat_people">--%>
<%--                            <div class="chat_img"><img src="https://ptetutorials.com/images/user-profile.png"--%>
<%--                                                       alt="sunil"></div>--%>
<%--                            <div class="chat_ib">--%>
<%--                                <h5>Sunil Rajput <span class="chat_date">Dec 25</span></h5>--%>
<%--                                <p>Test, which is a new approach to have all solutions--%>
<%--                                    astrology under one roof.</p>--%>
<%--                            </div>--%>
<%--                        </div>--%>
<%--                    </div>--%>
<%--                    <div class="chat_list">--%>
<%--                        <div class="chat_people">--%>
<%--                            <div class="chat_img"><img src="https://ptetutorials.com/images/user-profile.png"--%>
<%--                                                       alt="sunil"></div>--%>
<%--                            <div class="chat_ib">--%>
<%--                                <h5>Sunil Rajput <span class="chat_date">Dec 25</span></h5>--%>
<%--                                <p>Test, which is a new approach to have all solutions--%>
<%--                                    astrology under one roof.</p>--%>
<%--                            </div>--%>
<%--                        </div>--%>
<%--                    </div>--%>
<%--                    <div class="chat_list">--%>
<%--                        <div class="chat_people">--%>
<%--                            <div class="chat_img"><img src="https://ptetutorials.com/images/user-profile.png"--%>
<%--                                                       alt="sunil"></div>--%>
<%--                            <div class="chat_ib">--%>
<%--                                <h5>Sunil Rajput <span class="chat_date">Dec 25</span></h5>--%>
<%--                                <p>Test, which is a new approach to have all solutions--%>
<%--                                    astrology under one roof.</p>--%>
<%--                            </div>--%>
<%--                        </div>--%>
<%--                    </div>--%>
                </div>
            </div>
            <div class="mesgs">
                <div class="msg_history" id="messages">
<%--                    <div class="incoming_msg">--%>
<%--                        <div class="incoming_msg_img"><img src="https://ptetutorials.com/images/user-profile.png"--%>
<%--                                                           alt="sunil"></div>--%>
<%--                        <div class="received_msg">--%>
<%--                            <div class="received_withd_msg">--%>
<%--                                <p>Test which is a new approach to have all--%>
<%--                                    solutions</p>--%>
<%--                                <span class="time_date"> 11:01 AM    |    June 9</span></div>--%>
<%--                        </div>--%>
<%--                    </div>--%>
<%--                    <div class="outgoing_msg">--%>
<%--                        <div class="sent_msg">--%>
<%--                            <p>Test which is a new approach to have all--%>
<%--                                solutions</p>--%>
<%--                            <span class="time_date"> 11:01 AM    |    June 9</span></div>--%>
<%--                    </div>--%>
<%--                    <div class="incoming_msg">--%>
<%--                        <div class="incoming_msg_img"><img src="https://ptetutorials.com/images/user-profile.png"--%>
<%--                                                           alt="sunil"></div>--%>
<%--                        <div class="received_msg">--%>
<%--                            <div class="received_withd_msg">--%>
<%--                                <p>Test, which is a new approach to have</p>--%>
<%--                                <span class="time_date"> 11:01 AM    |    Yesterday</span></div>--%>
<%--                        </div>--%>
<%--                    </div>--%>
<%--                    <div class="outgoing_msg">--%>
<%--                        <div class="sent_msg">--%>
<%--                            <p>Apollo University, Delhi, India Test</p>--%>
<%--                            <span class="time_date"> 11:01 AM    |    Today</span></div>--%>
<%--                    </div>--%>
<%--                    <div class="incoming_msg">--%>
<%--                        <div class="incoming_msg_img"><img src="https://ptetutorials.com/images/user-profile.png"--%>
<%--                                                           alt="sunil"></div>--%>
<%--                        <div class="received_msg">--%>
<%--                            <div class="received_withd_msg">--%>
<%--                                <p>We work directly with our designers and suppliers,--%>
<%--                                    and sell direct to you, which means quality, exclusive--%>
<%--                                    products, at a price anyone can afford.</p>--%>
<%--                                <span class="time_date"> 11:01 AM    |    Today</span></div>--%>
<%--                        </div>--%>
<%--                    </div>--%>
<%--                    <div class="outgoing_msg">--%>
<%--                        <div class="sent_msg">--%>
<%--                            <p>Apollo University, Delhi, India Test</p>--%>
<%--                            <span class="time_date"> 11:01 AM    |    Today</span></div>--%>
<%--                    </div>--%>
<%--                    <div class="incoming_msg">--%>
<%--                        <div class="incoming_msg_img"><img src="https://ptetutorials.com/images/user-profile.png"--%>
<%--                                                           alt="sunil"></div>--%>
<%--                        <div class="received_msg">--%>
<%--                            <div class="received_withd_msg">--%>
<%--                                <p>We work directly with our designers and suppliers,--%>
<%--                                    and sell direct to you, which means quality, exclusive--%>
<%--                                    products, at a price anyone can afford.</p>--%>
<%--                                <span class="time_date"> 11:01 AM    |    Today</span></div>--%>
<%--                        </div>--%>
<%--                    </div>--%>
                </div>
                <div class="type_msg">
                    <div class="input_msg_write">
                        <input id="textMsg" type="text" class="write_msg" placeholder="Введите сообщение..." disabled/>
                        <button id="btnSend" class="msg_send_btn" type="button" disabled>
                            <img src="/content/images/send-icon.png" alt="..."/>
                            <i class="fa fa-paper-plane-o" aria-hidden="true"></i>
                        </button>
                    </div>
                </div>
            </div>
        </div>
        </div>
</div>
<script src="/content/js/models/Message.js"></script>
<script src="/content/js/chat.js"></script>
</body>
</html>

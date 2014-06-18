class Pong < Domain
  prop_accessor :paddles, :ball

  command :join do |player_number|
    paddle_index = player_number - 1

    if paddles[paddle_index]
      raise "There is already a player #{player_number}"
    end

    Paddle.new.tap do |paddle|
      alter.paddles[paddle_index] = paddle
      emit.paddle = paddle
    end

    emit.player_joined player_number
  end
end
